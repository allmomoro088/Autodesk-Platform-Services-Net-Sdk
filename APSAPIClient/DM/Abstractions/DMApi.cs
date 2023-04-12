using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM.Abstractions
{
    /// <summary>
    /// The base class for Data Management APIs
    /// </summary>
    public class DMApi : ApiBase
    {
        protected DMClient Client;

        public DMApi()
        {

        }
        public DMApi(ClientCredentials cc, IScope scope) : base (cc, scope)
        {

        }

        public override void SetAuthenticator(Authenticator authenticator)
        {
            Client.SetAuthenticator(authenticator);
            base.SetAuthenticator(authenticator);
        }
    }
}
