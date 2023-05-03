using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using Autodesk.PlatformServices.DM.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Objects APIs in Autodesk Platform Services
    /// </summary>
    public class ObjectsApi : DMApi
    {
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;

        /// <summary>
        /// The maximum size of chunks when uploading larger files. The default is 5MB
        /// </summary>
        public long ChunkSize { get; set; } = 5 * 1024 * 1024;

        /// <summary>
        /// The expiration for upload urls in minutes. The default is 5 minutes
        /// </summary>
        public int MinutesExpiration { get; set; } = 5;

        /// <summary>
        /// Creates an instance of <see cref="ObjectsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public ObjectsApi(ClientCredentials cc) : base(cc, new DataManagementScope())
        {
            Client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
            _dataBuilder = new DMDataBuilder();
        }

        /// <summary>
        /// Creates an instance of <see cref="ObjectsApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="dmClient">The DMClient being used to execute requests</param>
        /// <param name="requestBuilder">The DM Request Builder instance</param>
        /// <param name="dataBuilder">The DM Data Builder instance</param>
        public ObjectsApi(DMClient dmClient,
                          DMRequestBuilder requestBuilder,
                          DMDataBuilder dataBuilder)
        {
            Client = dmClient;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        /// <summary>
        /// Gets a collection of urls for downloading an object from Autodesk Platform Services
        /// </summary>
        /// <param name="bucketKey">The bucket key where the object is located</param>
        /// <param name="objectKey">The object key</param>
        /// <returns>An instance of <see cref="S3SignedDownloadUrls"/> containing the urls to be used during download</returns>
        public S3SignedDownloadUrls GetS3SignedDownloadUrls(string bucketKey, string objectKey)
        {
            var r = _requestBuilder
                .UseGetS3SignedDownloadUrls(bucketKey, objectKey)
                .Build();

            return Client.Execute<S3SignedDownloadUrls>(r, s =>
                {
                    //Creating new instance
                    var d = new S3SignedDownloadUrls();

                    //Parsing json
                    JObject j = JObject.Parse(s);

                    //Checking for complete url
                    if (j.SelectToken("status")?.ToString() == "complete")
                    {
                        d = JsonConvert.DeserializeObject<S3SignedDownloadUrls>(s, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });
                        d.Urls.Add("complete", j.SelectToken("url").ToString());
                    }
                    //Checking for chuncked urls
                    else if (j.SelectToken("status")?.ToString() == "chunked")
                        d = JsonConvert.DeserializeObject<S3SignedDownloadUrls>(s);

                    return d;
                });
        }
        
        /// <summary>
        /// Gets a collectio of urls for uploading an object to Autodesk Platform Services
        /// </summary>
        /// <param name="bucketKey">The bucket where the object will be located</param>
        /// <param name="objectKey">The object key</param>
        /// <param name="bytes">Number of bytes of the file</param>
        /// <returns>An instance of <see cref="S3SignedUploadUrls"/> containing the urls to be used during upload</returns>
        public S3SignedUploadUrls GetS3SignedUploadUrls(string bucketKey, string objectKey, long bytes)
        {
            string uploadKey = null;
            int maxParts = 0;
            int currentPart = 0;

            if (bytes < ChunkSize)
            {
                var r = _requestBuilder
                    .UseGetS3SignedUploadUrls(bucketKey, objectKey)
                    .Build();

                return Client.Execute<S3SignedUploadUrls>(r);
            }
            else
            {
                var urls = new S3SignedUploadUrls();
                maxParts = (int)Math.Round((double)(100 * (bytes / ChunkSize)))/100;
                if (bytes % ChunkSize != 0)
                    maxParts++;
                while (currentPart < maxParts)
                {
                    int parts = maxParts - currentPart >= 25 ? 25 : maxParts - currentPart;
                    RestRequest r = null;
                    if (uploadKey == null)
                    {
                        r = _requestBuilder
                            .UseGetS3SignedUploadUrls(bucketKey, objectKey, parts: parts)
                            .Build();
                    }
                    else
                    {
                        r = _requestBuilder
                            .UseGetS3SignedUploadUrls(bucketKey, objectKey, uploadKey, currentPart, parts, MinutesExpiration)
                            .Build();
                    }
                    var responseUrls = Client.Execute<S3SignedUploadUrls>(r);
                    foreach (string url in responseUrls.Urls)
                    {
                        urls.Urls.Add(url);
                    }
                    urls.UrlsExpiration = responseUrls.UrlsExpiration;
                    urls.UploadExpiration = responseUrls.UploadExpiration;
                    urls.UploadKey = responseUrls.UploadKey;
                    currentPart += parts;
                }
                return urls;
            }
        }

        /// <summary>
        /// Finishes the upload of an object to Autodesk Platform Services
        /// </summary>
        /// <param name="bucketKey">The bucket key where the object was uploaded</param>
        /// <param name="objectKey">The object key</param>
        /// <param name="uploadKey">The upload key provided by the API. Can be located at <see cref="S3SignedUploadUrls.UploadKey"/></param>
        /// <returns>The instance of the newly uploaded <see cref="Object"/></returns>
        public Object PostObject(string bucketKey, string objectKey, string uploadKey)
        {
            var data = new DMDataBuilder()
                .UseObject(uploadKey)
                .Build();

            var r = new DMRequestBuilder()
                .UsePostObject(bucketKey, objectKey, data)
                .Build();

            return Client.Execute<Object>(r);
        }

        /// <summary>
        /// Creates a copy of an existing object in the same bucket in Autodesk Platform Services
        /// </summary>
        /// <param name="bucketKey">The bucket where the existing object is located</param>
        /// <param name="fromObjectKey">The existing object's key</param>
        /// <param name="toObjectKey">The object key of the new copy</param>
        /// <returns>The instance of the newly copied <see cref="Object"/></returns>
        public Object PutObjectCopyTo(string bucketKey, string fromObjectKey, string toObjectKey)
        {
            var r = _requestBuilder
                .UsePutObjectCopyTo(bucketKey, fromObjectKey, toObjectKey)
                .Build();

            return Client.Execute<Object>(r);
        }
    }
}
