using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class MDClient : BaseClient
    {
        Authenticator _auth;

        public MDClient(Authenticator auth)
        {
            _auth = auth;
        }

        public override T Execute<T>(RestRequest r,
                                       Func<string, T> customParsing = null,
                                       Action<RestResponse> customErrHandling = null)
        {
            r = UseToken(r);
            return base.Execute(r, customParsing, customErrHandling);
        }

        public RestRequest UseToken(RestRequest r)
        {
            r.AddOrUpdateHeader("Authorization", $"Bearer {_auth.TwoLeggedToken.Access_Token}");
            return r;
        }
    }
}
