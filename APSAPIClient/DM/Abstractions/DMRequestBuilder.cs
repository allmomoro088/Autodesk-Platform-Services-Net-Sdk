using Autodesk.PlatformServices.Base;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

using Autodesk.PlatformServices.Utils;
using System.Globalization;
using System.Linq;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// The abstraction for building Data Management APIs requests
    /// </summary>
    public class DMRequestBuilder : RequestBuilderBase
    {
        /// <summary>
        /// Defines that the request will have the x-request-id header for tracking
        /// </summary>
        /// <param name="id">The <see cref="String"/> of a GUID</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public DMRequestBuilder IncludeXRequestId(string id)
        {
            Headers.Add("x-request-id", id);
            return this;
        }

        /// <summary>
        /// Defines that the request will have the x-user-id header for user context
        /// </summary>
        /// <param name="id">The userid aka AutodeskId or UID</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public DMRequestBuilder IncludeUseXUserId(string id)
        {
            Headers.Add("x-user-id", id);
            return this;
        }

        /// <summary>
        /// Allows setting custom endpoint, method and data for request
        /// </summary>
        /// <param name="endpoint">The resource to be used</param>
        /// <param name="method">HTTP Method</param>
        /// <param name="data">Stringfied data</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public DMRequestBuilder UseEndpoint(string endpoint,
                                              Method method = Method.Get,
                                              string data = null)
        {
            Resource = endpoint;
            Method = method;
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        #region Hubs Api

        /// <summary>
        /// Sets the request to get Data Management hubs
        /// </summary>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetHubs()
        {
            Resource = "project/v1/hubs";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get a specific Data Management hub
        /// </summary>
        /// <param name="hubId">The hub id to be requested</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetHub(string hubId)
        {
            Resource = $"project/v1/hubs/b.{hubId.TreatId()}";
            Method = Method.Get;
            return this;
        }

        #endregion

        #region Projects API

        /// <summary>
        /// Sets the request to get projects of a hub in Data Management
        /// </summary>
        /// <param name="hubId">The hub id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetProjects(string hubId)
        {
            Resource = $"project/v1/hubs/b.{hubId.TreatId()}/projects";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get a specific project of a hub in Data Management
        /// </summary>
        /// <param name="hubId">The hub id</param>
        /// <param name="projectId">The project id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetProject(string hubId, string projectId)
        {
            Resource = $"project/v1/hubs/b.{hubId.TreatId()}/projects/b.{projectId.TreatId()}";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get top folders from a specific project of a hub in Data Management
        /// </summary>
        /// <param name="hubId">The hub id</param>
        /// <param name="projectId">The project id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetTopFolders(string hubId, string projectId)
        {
            Resource = $"project/v1/hubs/b.{hubId.TreatId()}/projects/b.{projectId.TreatId()}/topFolders";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to create a storage location in a project where an Item will be uploaded later
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UsePostStorageLocation(string projectId, string data)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/storage";
            Method = Method.Post;
            Headers.Add("content-type", "application/vnd.api+json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }
        #endregion

        #region Folders Api

        /// <summary>
        /// Sets the request to get a specific folder within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="folderId">The folder id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetFolder(string projectId, string folderId)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/folders/{folderId}";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get the content of a specific folder within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="folderId">The folder id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetContents(string projectId, string folderId)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/folders/{folderId}/contents";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the reqeust to create a new folder within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UsePostFolder(string projectId, string data)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/folders";
            Method = Method.Post;
            Headers.Add("content-type", "application/vnd.api+json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        #endregion

        #region Items Api

        /// <summary>
        /// Sets the request to get a specific item within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="itemId">The item id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetItem(string projectId, string itemId)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/items/{itemId}";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get the latest version of a specific item within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="itemId">The item id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetItemTip(string projectId, string itemId)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/items/{itemId}/tip";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to create a new item within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UsePostItem(string projectId, string data)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/items";
            Method = Method.Post;
            Headers.Add("content-type", "application/json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        #endregion

        #region Versions Api

        /// <summary>
        /// Sets the request to get a specific item's version within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="versionId">The version id</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public DMRequestBuilder UseGetVersion(string projectId, string versionId)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/versions/{versionId.UrlEncode()}";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to create a new version of an item within a project in Data Management
        /// </summary>
        /// <param name="projectId">The project id</param>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public DMRequestBuilder UsePostVersion(string projectId, string data)
        {
            Resource = $"data/v1/projects/b.{projectId.TreatId()}/versions";
            Method = Method.Post;
            Headers.Add("content-type", "application/json");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        #endregion

        #region Objects Api

        /// <summary>
        /// Sets the request to get direct S3 download urls for a object in Data Management
        /// </summary>
        /// <param name="bucketKey">The bucket key where the object is located</param>
        /// <param name="objectKey">The object key</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetS3SignedDownloadUrls(string bucketKey, string objectKey)
        {
            Resource = $"oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3download";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to get direct S3 upload urls for a object in Data Management
        /// </summary>
        /// <param name="bucketKey">The bucket key where the object is going to be located</param>
        /// <param name="objectKey">The object key</param>
        /// <param name="uploadKey">The upload key provided by the API. Used if Start parameter isn't 1</param>
        /// <param name="start">The starting part number</param>
        /// <param name="parts">The number of parts to be generated</param>
        /// <param name="minutes">The expiration of urls in minutes</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetS3SignedUploadUrls(string bucketKey,
                                                        string objectKey,
                                                        string uploadKey = null,
                                                        int start = 1,
                                                        int parts = 1,
                                                        int minutes = 5)
        {
            Resource = $"oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3upload";
            Method = Method.Get;
            if (uploadKey != null)
                Parameters.Add(("uploadKey", uploadKey, ParameterType.QueryString));
            Parameters.Add(("firstPart", start, ParameterType.QueryString));
            Parameters.Add(("parts", parts, ParameterType.QueryString));
            Parameters.Add(("minutesExpiration", minutes, ParameterType.QueryString));

            return this;
        }

        /// <summary>
        /// Sets the request to finish the upload of an object using direct to S3 urls
        /// </summary>
        /// <param name="bucketKey">The bucket key where the object was uploaded to</param>
        /// <param name="objectKey">The object key</param>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns></returns>
        public DMRequestBuilder UsePostObject(string bucketKey, string objectKey, string data)
        {
            Resource = $"oss/v2/buckets/{bucketKey}/objects/{objectKey}/signeds3upload";
            Method = Method.Post;
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        /// <summary>
        /// Sets the request to create a copy of an object in the same bucket but with other object key
        /// </summary>
        /// <param name="bucketKey">The bucket key where the source object is located</param>
        /// <param name="fromObjectKey">The existing object's key</param>
        /// <param name="toObjectKey">The new copy object's key</param>
        /// <returns></returns>
        public DMRequestBuilder UsePutObjectCopyTo(string bucketKey, string fromObjectKey, string toObjectKey)
        {
            Resource = $"oss/v2/buckets/{bucketKey}/objects/{fromObjectKey}/copyto/{toObjectKey}";
            Method = Method.Put;

            return this;
        }

        #endregion

        #region Buckets Api

        /// <summary>
        /// Sets the request to get the buckets available for the app credentials
        /// </summary>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseGetBuckets()
        {
            Resource = "oss/v2/buckets";
            Method = Method.Get;
            return this;
        }

        /// <summary>
        /// Sets the request to create a new bucket
        /// </summary>
        /// <param name="data">The json payload data to be sent</param>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UsePostBucket(string data)
        {
            Resource = "oss/v2/buckets";
            Method = Method.Post;
            Headers.Add("content-type", "application/json");
            Headers.Add("x-ads-region", "US");
            Parameters.Add(("application/json", data, ParameterType.RequestBody));
            return this;
        }

        /// <summary>
        /// Sets the request to delete one of the buckets available for the app credentials
        /// </summary>
        /// <returns>This <see cref="DMRequestBuilder"/> instance</returns>
        public virtual DMRequestBuilder UseDeleteBucket(string bucketKey)
        {
            Resource = $"oss/v2/buckets/{bucketKey}";
            Method = Method.Delete;
            return this;
        }

        #endregion

        #region Build

        /// <summary>
        /// Builds the request using the resource, method, parameters and headers provided
        /// </summary>
        /// <returns>The <see cref="RestRequest"/> built with the data</returns>
        public override RestRequest Build()
        {
            var r = new RestRequest(Resource, Method);
            Headers.ToList().ForEach(h =>
                r.AddOrUpdateHeader(h.Key, h.Value)
            );
            Parameters.ToList().ForEach(x =>
                r.AddParameter(x.Item1, x.Item2, x.Item3.Value)    
            );

            ClearBuilder();

            return r;
        }

        /// <summary>
        /// Clears the data in this builder, for it to be reused further
        /// </summary>
        private void ClearBuilder()
        {
            Parameters = new List<(string, object, ParameterType?)>();
            Headers = new Dictionary<string, string>();
            Resource = null;
            Method = default;
        }

        #endregion
    }
}
