using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Auth.Exceptions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Items APIs from Autodesk Platform Services
    /// </summary>
    public class ItemsApi : DMApi
    {
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;

        /// <summary>
        /// Creates an instance of <see cref="ItemsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public ItemsApi(ClientCredentials cc) : base(cc, new DataManagementScope())
        {
            Client = new DMClient(Authenticator);
        }

        /// <summary>
        /// Creates an instance of <see cref="ItemsApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        /// <param name="client">The DM Client to be used on executing requests</param>
        /// <param name="requestBuilder"></param>
        /// <param name="dataBuilder"></param>
        public ItemsApi(ClientCredentials cc, DMClient client, DMRequestBuilder requestBuilder, DMDataBuilder dataBuilder) : base(cc, new DataManagementScope())
        {
            Client = client;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }
         /// <summary>
         /// Gets an item of a project by its id
         /// </summary>
         /// <param name="projectId">The project id where the item is located</param>
         /// <param name="itemId">The item id</param>
         /// <returns>The instance of <see cref="Item"/> for the provided id</returns>
        public Item GetItem(string projectId, string itemId)
        {
            var r = _requestBuilder
                .UseGetItem(projectId, itemId)
                .Build();

            return Client.ExecuteDMApi<Item>(r);
        }

        /// <summary>
        /// Gets the latest version of an item
        /// </summary>
        /// <param name="projectId">The project id where the item is located</param>
        /// <param name="itemId">The item id</param>
        /// <returns>The instance of the latest <see cref="Version"/> for the provided item id</returns>
        public Version GetItemTip(string projectId, string itemId)
        {
            var r = _requestBuilder
                .UseGetItemTip(projectId, itemId)
                .Build();

            return Client.ExecuteDMApi<Version>(r);
        }
         /// <summary>
         /// Creates a new item within a folder of a project
         /// </summary>
         /// <param name="projectId">The project id where the item will be located</param>
         /// <param name="fileName">The file name to be shown</param>
         /// <param name="parentId">The folder id where the item will be located. Aka parent folder</param>
         /// <param name="storageId">The storage id for this item. Generated on <see cref="ProjectsApi.PostStorage(string, string, string)"/></param>
         /// <returns>The instance of the newly created <see cref="Item"/></returns>
        public Item PostItem(string projectId, string fileName, string parentId, string storageId)
        {
            var data = _dataBuilder
                .UseItem(fileName, parentId, storageId)
                .Build();

            var r = _requestBuilder
                .UsePostItem(projectId, data)
                .Build();

            return Client.ExecuteDMApi<Item>(r, customErrHandling: response =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                    throw new ConflictException();
                else if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    throw new Exception(response.Content);
            });
        }
    }
}
