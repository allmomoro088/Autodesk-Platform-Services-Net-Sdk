using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Helpers
{
    internal static class MockRestResponseHandler <T>
    {
        internal static Mock<RestClient> SetupBasicResouce(T expectedResponse)
        {
            var r = new RestResponse();
            r.Content = JsonConvert.SerializeObject(expectedResponse);
            r.StatusCode = HttpStatusCode.OK;
            
            var handlerMock = new Mock<RestClient>();
            handlerMock
                .Protected()
                .Setup<RestResponse>(
                    "Execute",
                    ItExpr.IsAny<RestRequest>())
                .Returns(r);

            return handlerMock;
        }
    }
}
