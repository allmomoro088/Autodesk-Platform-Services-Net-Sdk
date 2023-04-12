using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class RestSharpFixtures
    {
        internal static RestRequest GetRequest() =>
            new RestRequest("", Method.Get);

        internal static RestRequest PostRequest() =>
            new RestRequest("", Method.Post);

        internal static RestRequest DeleteRequest() =>
            new RestRequest("", Method.Delete);
    }
}
