using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class HubsFixtures
    {
        internal static string RightId() =>
            "id1";
        internal static Hub RightModel() =>
            new Hub
            {
                Id = RightId()
            };

        internal static List<Hub> RightModelList() =>
            new List<Hub>
            {
                new Hub
                {
                    Id = RightId()
                },
                new Hub
                {
                    Id = "id2"
                }
            };
    }
}
