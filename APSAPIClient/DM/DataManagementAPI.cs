using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// The default implementation of <see cref="IDataManagementAPI"/> that contains all Data Management APIs
    /// </summary>
    public class DataManagementAPI : IDataManagementAPI
    {
        HubsApi _hubsApi;
        ProjectsApi _projectsApi;
        FoldersApi _foldersApi;
        ItemsApi _itemsApi;
        VersionsApi _versionsApi;
        ObjectsApi _objectsApi;
        BucketsApi _bucketsApi;

        /// <summary>
        /// Creates an instance of <see cref="DataManagementAPI"/>. Mainly used bu Dependency Injection
        /// </summary>
        /// <param name="hubsApi"></param>
        /// <param name="projectsApi"></param>
        /// <param name="foldersApi"></param>
        /// <param name="itemsApi"></param>
        /// <param name="objectsApi"></param>
        /// <param name="bucketsApi"></param>
        public DataManagementAPI(HubsApi hubsApi, ProjectsApi projectsApi, FoldersApi foldersApi, ItemsApi itemsApi, ObjectsApi objectsApi, BucketsApi bucketsApi)
        {
            _hubsApi = hubsApi;
            _projectsApi = projectsApi;
            _foldersApi = foldersApi;
            _itemsApi = itemsApi;
            _objectsApi = objectsApi;
            _bucketsApi = bucketsApi;
        }

        public HubsApi HubsApi
        {
            get { return _hubsApi; }
            set { _hubsApi = value; }
        }
        public ProjectsApi ProjectsApi
        {
            get { return _projectsApi; }
            set { _projectsApi = value; }
        }
        public FoldersApi FoldersApi
        {
            get { return _foldersApi; }
            set { _foldersApi = value; }
        }
        public ItemsApi ItemsApi
        {
            get { return _itemsApi; }
            set { _itemsApi = value; }
        }
        public VersionsApi VersionsApi
        {
            get { return _versionsApi; }
            set { _versionsApi = value; }
        }

        public ObjectsApi ObjectsApi
        {
            get { return _objectsApi; }
            set { _objectsApi = value; }
        }
        public BucketsApi BucketsApi
        { 
            get { return _bucketsApi; }
            set { _bucketsApi = value; }
        }
    }
}
