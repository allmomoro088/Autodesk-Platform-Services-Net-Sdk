using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest
{
    public static class RestSharpHelper
    {
        public static RestClient GetClient() =>
            new RestClient("https://developer.api.autodesk.com/");
    }
}
