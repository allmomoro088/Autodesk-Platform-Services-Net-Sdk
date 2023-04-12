using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// Autodesk Platform Services App Credentials, used to create authorization tokens
    /// </summary>
    public class ClientCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }

        /// <summary>
        /// Creates an instance of ClientCredentials, containing Client Id, Client Secret and RedirectUri
        /// </summary>
        /// <param name="clientId">Client Id of the APS app. Obtained at https://aps.autodesk.com/myapps/</param>
        /// <param name="clientSecret">Client Secret of the APS app. Obtained at https://aps.autodesk.com/myapps/</param>
        /// <param name="redirectUri">Uri used to return to a callback page, after user authorization flow. Can be updated or added at https://aps.autodesk.com/myapps/</param>
        public ClientCredentials(string clientId, string clientSecret, string redirectUri = null)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }
    }
}
