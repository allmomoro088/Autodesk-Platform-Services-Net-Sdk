using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class ACCClient : BaseClient
    {
        private Authenticator _auth;

        public ACCClient(Authenticator auth)
        {
            _auth = auth;
        }
    }
}
