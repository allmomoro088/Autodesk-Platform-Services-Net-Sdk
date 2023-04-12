using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Auth.Models;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// An abstraction for authentication during usage of the api
    /// <para>Currently uses Authentication OAuth V1</para>
    /// </summary>
    public class Authenticator
    {
        private TwoLeggedToken _t2l;
        private ThreeLeggedToken _t3l;

        private AuthClient _client;

        private string _clientId;
        private string _clientSecret;
        private string _redirectUri;
        private string _t3lIdentifier;

        private IScope _scope;
        private I2LOStorage _i2LOStorage;
        private I3LOStorage _i3LOStorage;

        /// <summary>
        /// The 2 legged authentication flow token associated with this Authenticator, automatically obtained and renewed
        /// </summary>
        public TwoLeggedToken TwoLeggedToken
        {
            get
            {
                if (_t2l == null)
                    _t2l = _i2LOStorage.Obtain();

                if (_t2l == null || _t2l.ExpirationDate < DateTime.Now)
                {
                    _t2l = GetTwoLegged(_scope.GetScope());
                }
                return _t2l;
            }
        }

        /// <summary>
        /// The 3 legged authentication flow token token associated with this Authenticator, automatically obtained and renewed
        /// </summary>
        public ThreeLeggedToken ThreeLeggedToken
        {
            get
            {
                if (_t3l == null && _t3lIdentifier != null)
                    _t3l = _i3LOStorage.Obtain(_t3lIdentifier);
                if (_t3l == null || _t3l.ExpirationDate < DateTime.Now)
                {
                    _t3l = GetThreeLegged(_scope.GetScope());
                    _t3lIdentifier = _t3lIdentifier ?? _t3l.GetIdentifierFromToken();
                }
                return _t3l;
            }
        }

        public I3LOStorage I3LOStorage
        {
            get
            {
                if (_i3LOStorage == null)
                    throw new MissingMemberException("I3LOStorage must be implemented and assigned when using three legged authentication");
                return _i3LOStorage;
            }
        }

        public string T3LIdentifier
        {
            get
            {
                if (_t3lIdentifier == null)
                    throw new MissingMemberException("I3LOStorage must be implemented and assigned when using three legged authentication");
                return _t3lIdentifier;
            }
        }

        /// <summary>
        /// Creates a Authenticator instance
        /// <para>Mainly used by Dependency Injection</para>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        /// <param name="authClient">Client used to make the requests during authentication</param>
        /// <param name="scope">Token scopes</param>
        /// <param name="i2LOStorage">Two legged authentication storage implementation. Used to store and obtain tokens</param>
        /// <param name="i3LOStorage">Three legged authentication storage implementation. Used to store and obtain 3 legged tokens</param>
        public Authenticator(ClientCredentials cc,
                             AuthClient authClient,
                             IScope scope,
                             I2LOStorage i2LOStorage = null,
                             I3LOStorage i3LOStorage = null)
        {
            _clientId = cc.ClientId;
            _clientSecret = cc.ClientSecret;
            _redirectUri = cc.RedirectUri;
            _client = authClient;
            _scope = scope;
            _i3LOStorage = i3LOStorage;
        }

        /// <summary>
        /// Creates a Authenticator instance
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        /// <param name="scope">Token scopes</param>
        /// <param name="i2LOStorage">Two legged authentication storage implementation. Used to store and obtain tokens</param>
        /// <param name="i3LOStorage">Three legged authentication storage implementation. Used to store and obtain 3 legged tokens</param>
        public Authenticator(ClientCredentials cc,
                             IScope scope,
                             I2LOStorage i2LOStorage = null,
                             I3LOStorage i3LOStorage = null)
        {
            _clientId = cc.ClientId;
            _clientSecret = cc.ClientSecret;
            _redirectUri = cc.RedirectUri;
            _scope = scope;
            _client = new AuthClient();
            if (i2LOStorage!= null)
                _i2LOStorage = i2LOStorage;
            else
                _i2LOStorage = new Json2LOStorage();

            _i3LOStorage = i3LOStorage;
        }

        /// <summary>
        /// Load an existing 3 legged token into this Authenticator instance and starts using it from now on
        /// </summary>
        /// <param name="token">Three legged access token</param>
        public void LoadExistingToken(string token)
        {
            _t3lIdentifier = token.GetIdentifierFromToken();
            _t3l = I3LOStorage.Obtain(_t3lIdentifier);
        }

        /// <summary>
        /// Gets user profile information using three legged authentication
        /// </summary>
        /// <returns>An instance of <see cref="Me"/> class, with information from the user authenticated</returns>
        public Me GetMe()
        {
            var r = new AuthRequestBuilder()
                .UseGetMe(ThreeLeggedToken.Access_Token)
                .Build();

            return _client.Execute<Me>(r);
        }

        /// <summary>
        /// Authenticate using 2 legged flow with the Client Credentials provided on constructor
        /// <para>Uses I2LOStorage interface implementation to store the token</para>
        /// </summary>
        /// <param name="scope">Token scopes</param>
        /// <returns>An instance of <see cref=">"/> that contains the access token used on Authorization Header during api calls</returns>
        internal TwoLeggedToken GetTwoLegged(Scope scope)
        {
            var r = new AuthRequestBuilder()
                .WithClientCredentials(_clientId, _clientSecret)
                .UseTwoLegged()
                .SetScope(scope)
                .Build();

            var token = _client.Execute<TwoLeggedToken>(r);
            _i2LOStorage.Store(token);

            return token;
        }

        /// <summary>
        /// Authenticate using 3 legged flow with the Client Credentials provided on constructor
        /// <para>Uses I3LOStorage interface implementation to get RefreshToken, AuthorizationCode, ResponseType and to store tokens data</para>
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        internal ThreeLeggedToken GetThreeLegged(Scope scope)
        {
            var code = _i3LOStorage.GetRefreshToken(_t3lIdentifier);
            var t = AuthType.RefreshToken;
            if (string.IsNullOrEmpty(code))
            {
                code = _i3LOStorage.GetCode();
                t = AuthType.Code;
            }

            if (string.IsNullOrEmpty(code))
                _i3LOStorage.ObtainCode(BuildObtainCodeUrl(_i3LOStorage.ResponseType()));

            var r = new AuthRequestBuilder()
                .WithClientCredentials(_clientId, _clientSecret)
                .SetScope(scope)
                .SetRedirectUri(_redirectUri)
                .UseThreeLegged(t, code)
                .Build();

            var token = _client.Execute<ThreeLeggedToken>(r);
            _i3LOStorage.Store(token, _t3lIdentifier ?? token.GetIdentifierFromToken());

            return token;
        }

        /// <summary>
        /// Used to craft the url used to redirect the user for 3 legged auth flow
        /// </summary>
        /// <param name="responseType">The response type. See <see href="https://aps.autodesk.com/en/docs/oauth/v1/reference/http/authorize-GET/#query-string-parameters"/></param>
        /// <returns></returns>
        private string BuildObtainCodeUrl(string responseType)
        {
            return new AuthorizeUriBuilder()
                .UseClientId(_clientId)
                .UseRedirectUri(_redirectUri)
                .SetScope(_scope.GetScope())
                .UseResponseType(responseType)
                .Build();
        }
    }
}
