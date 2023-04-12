using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Autodesk.PlatformServices.MD
{
    public class JobsApi : ApiBase
    {
        MDClient _client;
        MDRequestBuilder _requestBuilder;
        MDDataBuilder _dataBuilder;
        public JobsApi(ClientCredentials cc) : base (cc, new DataManagementScope())
        {
            _client = new MDClient(Authenticator);
            _requestBuilder = new MDRequestBuilder();
            _dataBuilder = new MDDataBuilder();
        }

        public JobsApi(MDClient client, MDRequestBuilder requestBuilder, MDDataBuilder dataBuilder)
        {
            _client = client;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        public Job PostJob(string urn,
                           bool compressedUrn,
                           string rootFileName,
                           string region,
                           string format,
                           List<string> views = null,
                           Dictionary<string, object> advanced = null)
        {
            //Creating data for job request
            var data = new MDDataBuilder()
                .UsePostJob(urn, compressedUrn, rootFileName, region, format, views, advanced)
                .Build(x =>
                {
                    //Custom serialization
                    return JsonConvert.SerializeObject(x, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                });

            //Building request
            var r = new MDRequestBuilder()
                .UsePostJob(data)
                .Build();

            return _client.Execute<Job>(r);
        }
    }
}
