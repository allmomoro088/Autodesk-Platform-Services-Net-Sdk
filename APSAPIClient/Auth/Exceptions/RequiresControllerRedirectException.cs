using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Exceptions
{
    /// <summary>
    /// Used in <see cref="I3LOStorage"/> implementation when required the redirection to Authorization Url
    /// <para>Mainly used in Controller based applications</para>
    /// </summary>
    public class RequiresControllerRedirectException : Exception
    {
        /// <summary>
        /// The url to Autodesk Authorization page
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Creates an instance. Requires the Authorization Url
        /// </summary>
        /// <param name="url">Autodesk Authorization page url</param>
        public RequiresControllerRedirectException(string url)
        {
            Url = url;
        }
    }
}
