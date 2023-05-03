using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest
{
    internal static class APSFixtures
    {
        internal static string RightClientId() =>
            "CLIENT_ID";

        internal static string RightClientSecret() =>
            "CLIENT_SECRET";

        internal static string RightRedictUri() =>
            "http://localhost:8080/";
    }
}
