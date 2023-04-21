using Autodesk.PlatformServices.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// Builder class for the Authorization Uri
    /// </summary>
    public class AuthorizeUriBuilder
    {
        string _clientId;
        string _redirectUri;
        Scope _scope;
        string _responseType;

        /// <summary>
        /// Declares the usage of Client Id in the Uri
        /// </summary>
        /// <param name="clientId">Autodesk Platform Services App Client Id</param>
        /// <returns>This <see cref="AuthorizeUriBuilder"/> instance</returns>
        public AuthorizeUriBuilder UseClientId(string clientId)
        {
            _clientId = clientId;
            return this;
        }

        /// <summary>
        /// Declares the usage of a Redirect Uri or Callback in the Uri
        /// </summary>
        /// <param name="redirectUri">The uri where the Authorize page should send the user after authentication (Callback)</param>
        /// <returns>This <see cref="AuthorizeUriBuilder"/> instance</returns>
        public AuthorizeUriBuilder UseRedirectUri(string redirectUri)
        {
            _redirectUri = redirectUri;
            return this;
        }

        /// <summary>
        /// Sets the scope of the token generated afterwards
        /// </summary>
        /// <param name="scope">Scope of the token generated afterwards</param>
        /// <returns>This <see cref="AuthorizeUriBuilder"/> instance</returns>
        public AuthorizeUriBuilder SetScope(Scope scope)
        {
            _scope = scope;
            return this;
        }

        /// <summary>
        /// Sets the Response Type when the Authorization page redirects back to the callback
        /// </summary>
        /// <param name="responseType">Response Type. <see href="https://aps.autodesk.com/en/docs/oauth/v1/reference/http/authorize-GET/#query-string-parameters"/></param>
        /// <returns>This <see cref="AuthorizeUriBuilder"/> instance</returns>
        public AuthorizeUriBuilder UseResponseType (string responseType)
        {
            _responseType = responseType;
            return this;
        }

        /// <summary>
        /// Builds the Uri used to redirect to Autodesk Authorization page for 3 legged auth flows
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            return $"https://developer.api.autodesk.com/authentication/v2/authorize?client_id={_clientId}&response_type={_responseType}&redirect_uri={_redirectUri}&scope={_scope.Stringfy()}";
        }
    }
}
