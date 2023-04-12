using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class FoldersFixtures
    {
        internal static Folder RightFolder() =>
            new Folder
            {
                Id = ProjectsFixtures.RightFolderId()
            };

        internal static Contents RightContents() =>
            new Contents
            {
                
            };

        internal static string RightFolderName() =>
            "My Folder";
    }
}
