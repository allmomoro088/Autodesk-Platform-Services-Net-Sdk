using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Models
{
    /// <summary>
    /// Represents user information obtained from Autodesk Platform Services using /userprofile/v1/users/@me
    /// <para>For more information see: <see href="https://aps.autodesk.com/en/docs/oauth/v2/reference/http/users-@me-GET/"/></para>
    /// </summary>
    public class Me
    {
        /// <summary>
        /// User Id
        /// <para>Also found as UID or AutodeskId</para>
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User's email address
        /// </summary>
        public string EmailId { get; set; }

        /// <summary>
        /// User's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// If user's email is verified
        /// </summary>
        public string EmailVerified { get; set; }

        /// <summary>
        /// 2-letter country code
        /// </summary>
        /// <example>
        /// US
        /// </example>
        public string CountryCode { get; set; }

        /// <summary>
        /// 2-letter language code
        /// </summary>
        /// <example>
        /// en
        /// </example>
        public string Language { get; set; }


        public bool Optin { get; set; }

        /// <summary>
        /// Last time user information was modified
        /// </summary>
        public string LastModified { get; set; }

        /// <summary>
        /// User's profile pictures in various sizes
        /// </summary>
        public Dictionary<string, string> ProfileImages { get; set; }

        /// <summary>
        /// User profile website url
        /// </summary>
        public string WebsiteUrl { get; set; }


        public string EidmGuid { get; set; }
    }
}
