using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

using Version = Autodesk.PlatformServices.DM.Version;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Versions APIs in Autodesk Platform Services
    /// </summary>
    public class VersionsApi : ApiBase
    {
        DMClient _client;
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;
        string _accountId;

        /// <summary>
        /// Creates an instance of <see cref="VersionsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public VersionsApi(ClientCredentials cc) : base(cc, new DataManagementScope())
        {
            _client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
            _dataBuilder = new DMDataBuilder();
        }
         /// <summary>
         /// Creates an instance of <see cref="VersionsApi"/>. Mainly used by Dependency Injection
         /// </summary>
         /// <param name="dMClient">The DMClient used to execute requests</param>
         /// <param name="requestBuilder">The DM Request Builder instance</param>
         /// <param name="dataBuilder">The DM Data Builder instance</param>
        public VersionsApi(DMClient dMClient,
                           DMRequestBuilder requestBuilder,
                           DMDataBuilder dataBuilder)
        {
            _client = dMClient;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        /// <summary>
        /// Gets a version by its id
        /// </summary>
        /// <param name="projectId">The project id where the version is located</param>
        /// <param name="versionId">The version id</param>
        /// <returns>The instance of the <see cref="Version"/> for the provided id</returns>
        public Version GetVersion(string projectId, string versionId)
        {
            var r = _requestBuilder
                .UseGetVersion(projectId, versionId)
                .Build();

            return _client.Execute<Version>(r);
        } 

        /// <summary>
        /// Creates a new version for an item of a project
        /// </summary>
        /// <param name="projectId">The project id where the item is located</param>
        /// <param name="fileName">The file name to be used</param>
        /// <param name="itemId">The item id</param>
        /// <param name="storageId">The storage id of the new uploaded object to be linked to the new version</param>
        /// <returns>The instance of the newly created <see cref="Version"/></returns>
        public Version PostVersion(string projectId, string fileName, string itemId, string storageId)
        {
            var data = _dataBuilder
                .UseVersion(fileName, itemId, storageId)
                .Build();

            var r = _requestBuilder
                .UsePostVersion(projectId, data)
                .Build();

            return _client.Execute<Version>(r);
        }
    }
}
