using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class ItemsFixtures
    {
        internal static string RightItemId() =>
            "item1";

        internal static Item RightItem() =>
            new Item
            {
                Id = RightItemId()
            };

        internal static string RightFileName() =>
            "filename.dwg";
    }
}
