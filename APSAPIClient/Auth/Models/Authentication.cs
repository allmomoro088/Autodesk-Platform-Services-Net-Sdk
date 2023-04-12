using Autodesk.PlatformServices.Auth.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    public class Authentication
    {
        private Authenticator authenticator;

        public TwoLeggedToken TwoLeggedToken
        {
            get
            {
                return authenticator.TwoLeggedToken;
            }
        }

        public Authentication(ClientCredentials cc, params Scope[] scopes)
        {
            Scope s = 0;
            foreach (var scope in scopes)
            {
                s |= scope;
            }
            authenticator = new Authenticator(cc, new DataManagementScope());
        }
    }
}
