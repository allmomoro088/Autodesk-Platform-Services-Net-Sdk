using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// A abstraction class for generating the requests used for Authentication API
    /// </summary>
    public class AuthRequestBuilder : RequestBuilderBase
    {
        private string _clientId;
        private string _clientSecret;
        private string _redirectUri;

        /// <summary>
        /// Define the Client Credentials that are going to be used in the request
        /// </summary>
        /// <param name="clientId">Client Id of the APS app. Obtained at https://aps.autodesk.com/myapps/</param>
        /// <param name="clientSecret">Client Secret of the APS app. Obtained at https://aps.autodesk.com/myapps/</param>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder WithClientCredentials(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
            return this;
        }

        /// <summary>
        /// Declares that Two Legged Authentication workflow is being used in this request
        /// <para>Cannot be used together with UseThreeLegged</para>
        /// </summary>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder UseTwoLegged()
        {
            Resource = "authentication/v2/token";
            Method = Method.Post;
            Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            Headers.Add("Authorization", $"Basic {GetEncodedClientIdAndClientSecret()}");
            Parameters.Add(("grant_type", "client_credentials", null));
            return this;
        }

        /// <summary>
        /// Sets the scope that the token should have
        /// </summary>
        /// <param name="scope">Token scope</param>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder SetScope(Scope scope)
        {
            Parameters.Add(("scope", scope.Stringfy(), ParameterType.QueryString));
            return this;
        }

        /// <summary>
        /// Sets the Redirect Uri or Callback Url where Autodesk Authorization page will redirect to after
        /// </summary>
        /// <param name="redirect_uri">The Redirect or Callback Uri used</param>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder SetRedirectUri(string redirect_uri)
        {
            _redirectUri = redirect_uri;
            return this;
        }

        /// <summary>
        /// Declares that Three Legged Authentication workflow is being used in this request
        /// <para>Cannot be used together with UseTwoLegged</para>
        /// <para>Requires Redirect Uri to be filled</para>
        /// </summary>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder UseThreeLegged(AuthType type, string code)
        {
            Resource = "authentication/v2/token";
            Method = Method.Post;
            Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            Headers.Add("Authorization", $"Basic {GetEncodedClientIdAndClientSecret()}");
            Parameters.Add(("redirect_uri", _redirectUri, null));
            ParseAuthTypeToParameterAndAddCode(type, code);
            return this;
        }

        /// <summary>
        /// Defines the request to be created to get user's profile information
        /// </summary>
        /// <param name="token">The authorization token being used</param>
        /// <returns>This <see cref="AuthRequestBuilder"/> instance</returns>
        public AuthRequestBuilder UseGetMe(string token)
        {
            Resource = "userprofile/v1/users/@me";
            Method = Method.Get;
            Headers.Add("Authorization", $"Bearer {token}");
            return this;
        }

        /// <summary>
        /// Builds the request with the options used previously
        /// </summary>
        /// <returns>The <see cref="RestRequest"/> with resource, method, parameters and headers set</returns>
        public override RestRequest Build()
        {
            var r = new RestRequest(Resource, Method);
            Headers.ToList().ForEach(x =>
                r.AddOrUpdateHeader(x.Key, x.Value)
            );
            Parameters.ToList().ForEach(x =>
            {
                if (x.Item3 == null)
                    r.AddParameter(x.Item1, x.Item2.ToString());
                else
                    r.AddParameter(x.Item1, x.Item2.ToString(), x.Item3.Value);
            });
            ClearInputs();
            return r;
        }

        /// <summary>
        /// Clears the inputs used in the builder
        /// </summary>
        private void ClearInputs()
        {
            Resource = null;
            Method = default;
            Headers = new Dictionary<string, string>();
            Parameters = new List<(string, object, ParameterType?)>();
        }

        /// <summary>
        /// Translates AuthType and the code to parameters
        /// </summary>
        /// <param name="type">Type of code that is being used</param>
        /// <param name="code">The code to be used</param>
        private void ParseAuthTypeToParameterAndAddCode(AuthType type, string code)
        {
            string grant = "";
            switch (type)
            {
                case AuthType.Code:
                    grant = "authorization_code";
                    Parameters.Add(("code", code, null));
                    break;
                case AuthType.RefreshToken:
                    grant = "refresh_token";
                    Parameters.Add(("refresh_token", code, null));
                    break;
                default:
                    break;
            }
            Parameters.Add(("grant_type", grant, null));
        }

        private string GetEncodedClientIdAndClientSecret()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
        }
    }
}
