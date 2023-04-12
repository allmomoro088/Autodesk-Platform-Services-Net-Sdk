using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// The interface used to store tokens obtained via Three Legged Authentication flow
    /// </summary>
    public interface I3LOStorage
    {
        /// <summary>
        /// Gets the authorization code from somewhere
        /// </summary>
        /// <example>
        /// Obtaining the code from HttpContext
        /// <code>
        /// return httpContext?.Request?.Query["code"].ToString();
        /// </code>
        /// </example>
        /// <returns>A <see cref="String"/> of the authorization code to be used in the request</returns>
        string GetCode();

        /// <summary>
        /// Gets the Refresh token for a specific userid
        /// </summary>
        /// <param name="identifier">The Autodesk userid to find the refresh token</param>
        /// <returns>A <see cref="String"/> of the refresh token to be used in the request for renewing the token</returns>
        string GetRefreshToken(string identifier);

        /// <summary>
        /// Used when there is no Authorization code stored. Usually redirects users in a webapp to Autodesk's Authorization page
        /// </summary>
        /// <param name="url">The url where the user should be redirected to</param>
        void ObtainCode(string url);

        /// <summary>
        /// Gets the response type expected from Autodesk Authorization page after the redirect
        /// </summary>
        /// <returns>A <see cref="String"/> with the response type</returns>
        string ResponseType();

        /// <summary>
        /// Obtain an stored token by its identifier
        /// </summary>
        /// <param name="identifier">Usually the userid present in the access token</param>
        /// <returns>A <see cref="ThreeLeggedToken"/> for that identifier</returns>
        ThreeLeggedToken Obtain(string identifier);

        /// <summary>
        /// Stores the Three Legged token using the identifier as key
        /// </summary>
        /// <param name="t">The <see cref="ThreeLeggedToken"/> instance being stored</param>
        /// <param name="identifier">The identifier for the token, usually userid</param>
        void Store(ThreeLeggedToken t, string identifier);
    }
}
