using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    /// <summary>
    /// The base class for RequestBuilders. Abstracts the request creation
    /// </summary>
    public abstract class RequestBuilderBase
    {
        /// <summary>
        /// Contains all headers for the request being built
        /// </summary>
        public virtual Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Contains all parameters for the request being built
        /// </summary>
        public virtual List<(string, object, ParameterType?)> Parameters { get; set; } = new List<(string, object, ParameterType?)>();

        /// <summary>
        /// The method the request should be
        /// </summary>
        public virtual Method Method { get; set; }

        /// <summary>
        /// The resource being used
        /// </summary>
        public virtual string Resource { get; set; }

        /// <summary>
        /// Builds the request with provided data
        /// </summary>
        /// <returns>The <see cref="RestRequest"/> instance for the request built</returns>
        public abstract RestRequest Build();
    }
}
