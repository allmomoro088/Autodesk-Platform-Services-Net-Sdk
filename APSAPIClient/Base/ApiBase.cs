using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    /// <summary>
    /// A base class for APIs that contains the <see cref="Autodesk.PlatformServices.Auth.Authenticator"/>
    /// </summary>
    public abstract class ApiBase
    {
        internal Authenticator Authenticator { get; set; }

        public ApiBase()
        {

        }
        public ApiBase(ClientCredentials cc, IScope scope)
        {
            Authenticator = new Authenticator(cc, scope);
        }

        /// <summary>
        /// Set the <see cref="Autodesk.PlatformServices.Auth.Authenticator"/> to a custom one
        /// </summary>
        /// <param name="authenticator">The <see cref="Autodesk.PlatformServices.Auth.Authenticator"/> instance to be used</param>
        public virtual void SetAuthenticator(Authenticator authenticator)
        {
            Authenticator = authenticator;
        }
    }
}
