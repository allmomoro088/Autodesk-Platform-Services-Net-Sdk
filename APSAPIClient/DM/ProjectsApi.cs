using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM.Abstractions;
using Autodesk.PlatformServices.MD;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Project APIs on Autodesk Platform Services
    /// </summary>
    public class ProjectsApi : DMApi
    {
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;
        string _accountId;

        /// <summary>
        /// Creates an instance of <see cref="ProjectsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        /// <param name="accountId">The account id to be used</param>
        public ProjectsApi(ClientCredentials cc, string accountId) : base(cc, new DataManagementScope())
        {
            Client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
            _dataBuilder = new DMDataBuilder();
            _accountId = accountId;
        }

        /// <summary>
        /// Creates an instance of <see cref="ProjectsApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        /// <param name="dmClient">The DMClient instance used to execute requests</param>
        /// <param name="requestBuilder">The DM Request Builder instance</param>
        /// <param name="dataBuilder">The DM Data Builder instance</param>
        public ProjectsApi(ClientCredentials cc,
                           DMClient dmClient,
                           DMRequestBuilder requestBuilder,
                           DMDataBuilder dataBuilder) : base (cc, new DataManagementScope())
        {
            Client = dmClient;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        /// <summary>
        /// Gets all projects of a hub in Autodesk Platform Services
        /// </summary>
        /// <param name="accountId">The account id to be used</param>
        /// <returns>A list of <see cref="Project"/> on that account</returns>
        public IEnumerable<Project> GetProjects(string accountId = null)
        {
            var r = _requestBuilder
                .UseGetProjects(_accountId ?? accountId)
                .Build();

            return Client.ExecutePaginated<List<Project>, Project>(r);
        }

        /// <summary>
        /// Gets a project by its id
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="accountId">The account id or hub id where the project is located</param>
        /// <returns></returns>
        public Project GetProject(string projectId, string accountId = null)
        {
            var r = _requestBuilder
                .UseGetProject(accountId ?? _accountId, projectId)
                .Build();

            return Client.ExecuteDMApi<Project>(r);
        }

        /// <summary>
        /// Gets top folders of a project
        /// </summary>
        /// <param name="hubId">The account or hub id</param>
        /// <param name="projectId">The project id</param>
        /// <returns>A list of the top <see cref="Folder"/>s of the project</returns>
        public IEnumerable<Folder> GetTopFolders(string hubId, string projectId)
        {
            var r = _requestBuilder
                .UseGetTopFolders(hubId, projectId)
                .Build();

            return Client.ExecuteDMApi<List<Folder>>(r);
        }
         /// <summary>
         /// Creates an storage in the project, where a file will be uploaded
         /// </summary>
         /// <param name="projectId">The project where the storage will be created</param>
         /// <param name="fileName">The file name to be used</param>
         /// <param name="parentId">The folder id where the storage should be. Aka parent folder id</param>
         /// <returns>The instance of the newly created <see cref="StorageLocation"/></returns>
        public StorageLocation PostStorage(string projectId, string fileName, string parentId)
        {
            var data = _dataBuilder
                .UseStorageLocation(fileName, parentId)
                .Build();

            var r = _requestBuilder
                .UsePostStorageLocation(projectId, data)
                .Build();

            return Client.ExecuteDMApi<StorageLocation>(r, customErrHandling: response =>
            {
                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    throw new Exception(response.Content);
            });
        }
    }
}
