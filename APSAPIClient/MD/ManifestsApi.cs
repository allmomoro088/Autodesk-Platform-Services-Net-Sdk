using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.MD
{
    public class ManifestsApi : ApiBase
    {
        MDClient _client;
        public ManifestsApi(ClientCredentials cc) : base(cc, new DataManagementScope())
        {
            _client = new MDClient(Authenticator);
        }

        public Manifest GetManifest(string urn, bool isBase64)
        {
            var r = new MDRequestBuilder()
                .UseGetManifest(urn, isBase64)
                .Build();

            return _client.Execute<Manifest>(r);
        }

        public void DeleteManifest(string urn, bool isBase64)
        {
            var r = new MDRequestBuilder()
                .UseDeleteManifest(urn, isBase64)
                .Build();

            _client.Execute(r, s =>
            {
                var j = JObject.Parse(s);
                return j.SelectToken("result")?.ToString() == "success" ? true : false;
            });
        }
    }
}
