using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// The interface containing all Data Management APIs
    /// </summary>
    public interface IDataManagementAPI
    {
        public HubsApi HubsApi { get; set; }
        public ProjectsApi ProjectsApi { get; set; }
        public FoldersApi FoldersApi { get; set; }
        public ItemsApi ItemsApi { get; set; }
        public VersionsApi VersionsApi { get; set; }
        public BucketsApi BucketsApi { get; set; }
        public ObjectsApi ObjectsApi { get; set; }
    }
}
