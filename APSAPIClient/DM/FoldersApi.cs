using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Auth.Exceptions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM.Abstractions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Folders APIs in Autodesk Platform Services
    /// </summary>
    public class FoldersApi : DMApi
    {
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;

        /// <summary>
        /// Creates an instance of <see cref="FoldersApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public FoldersApi(ClientCredentials cc) : base (cc, new DataManagementScope())
        {
            Client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
            _dataBuilder = new DMDataBuilder();
        }

        /// <summary>
        /// Creates an instance of <see cref="FoldersApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="dmClient">The DMClient to be used on executing requests</param>
        /// <param name="requestBuilder">The request builder instance</param>
        /// <param name="dataBuilder">The data builder instance</param>
        public FoldersApi(DMClient dmClient,
                          DMRequestBuilder requestBuilder,
                          DMDataBuilder dataBuilder)
        {
            Client = dmClient;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        /// <summary>
        /// Gets a folder of a project by its id
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="folderId">The folder id</param>
        /// <returns>The instance of <see cref="Folder"/> for the provided id</returns>
        public Folder GetFolder(string projectId, string folderId)
        {
            var r = _requestBuilder
                .UseGetFolder(projectId, folderId)
                .Build();

            return Client.ExecuteDMApi<Folder>(r);
        }

        /// <summary>
        /// Gets the contents of a folder in a project
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="folderId">The folder id</param>
        /// <returns>The instance of <see cref="Contents"/> for that folder id</returns>
        public Contents GetContents(string projectId, string folderId)
        {
            var r = _requestBuilder
                .UseGetContents(projectId, folderId)
                .Build();

            return Client.Execute<Contents, Folder, Item, Version>(r);
        }

        /// <summary>
        /// Creates a new folder within a project
        /// </summary>
        /// <param name="projectId">The project id where the folder is being created</param>
        /// <param name="folderName">The name of the new folder</param>
        /// <param name="parentId">The folder id where the new folder will be located. Aka parent folder's id</param>
        /// <returns>The instance of the newly created <see cref="Folder"/></returns>
        public Folder PostFolder(string projectId, string folderName, string parentId)
        {
            var data = _dataBuilder
                .UseFolder(folderName, parentId)
                .Build();

            var r = _requestBuilder
                .UsePostFolder(projectId, data)
                .Build();

            return Client.ExecuteDMApi<Folder>(r, customErrHandling: (response) =>
            {
                if (response.StatusCode == HttpStatusCode.Conflict)
                    throw new ConflictException(response.Content);
                else if (response.StatusCode != HttpStatusCode.Created)
                    throw new Exception(response.Content);

            });
        }
    }
}
