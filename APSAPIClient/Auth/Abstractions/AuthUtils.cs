using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Abstractions
{
    public static class AuthUtils
    {
        /// <summary>
        /// Reads the provided token to acquire the userid in it
        /// </summary>
        /// <param name="t">The instance of <see cref="ThreeLeggedToken"/> to get the identifier from</param>
        /// <returns></returns>
        public static string GetIdentifierFromToken(this ThreeLeggedToken t)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(t.Access_Token);
            return token.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
        }

        /// <summary>
        /// Reads the provided token to acquire the userid in it
        /// </summary>
        /// <param name="s">The access token text to get the identifier from</param>
        /// <returns></returns>
        public static string GetIdentifierFromToken(this string s)
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(s);
            return token.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
        }
    }
}
