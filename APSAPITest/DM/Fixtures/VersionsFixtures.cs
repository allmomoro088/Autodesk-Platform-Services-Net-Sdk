using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Version = Autodesk.PlatformServices.DM.Version;

namespace APSAPITest.DM.Fixtures
{
    internal static class VersionsFixtures
    {
        internal static string RightVersionId() =>
            "version1";

        internal static Version RightVersion() =>
            new Version
            {
                Id = RightVersionId()
            };
    }
}
