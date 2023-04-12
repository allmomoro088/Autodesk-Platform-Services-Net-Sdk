using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class ProjectsFixtures
    {
        internal static string RightId() =>
            "proj1";

        internal static List<Project> RightModelList() =>
            new List<Project>()
            {
                new Project
                {
                    Id = RightId()
                },
                new Project
                {
                    Id = "proj2"
                }
            };

        internal static Project RightModel() =>
            new Project
            {
                Id = RightId()
            };

        internal static List<Folder> RightFolderList() =>
            new List<Folder>()
            {
                new Folder
                {
                    Id = RightId()
                },
                new Folder
                {
                    Id = "proj2"
                }
            };

        internal static string RightFileName() =>
            "file.dwg";

        internal static string RightFolderId() =>
            "urn:folder1";

        internal static StorageLocation RightStorageLocation() =>
            new StorageLocation
            {
                Id = "storageLocation"
            };
    }
}
