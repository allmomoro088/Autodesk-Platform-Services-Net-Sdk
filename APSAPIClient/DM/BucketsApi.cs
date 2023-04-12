using Autodesk.PlatformServices.Auth;
using Autodesk.PlatformServices.Auth.Abstractions;
using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// A collection of Data Management Bucket APIs in Autodesk Platform Services
    /// </summary>
    public class BucketsApi : ApiBase
    {
        DMClient _client;
        DMRequestBuilder _requestBuilder;
        DMDataBuilder _dataBuilder;

        /// <summary>
        /// Creates an instance of <see cref="BucketsApi"/>
        /// </summary>
        /// <param name="cc">Client Credentials used to authenticate</param>
        public BucketsApi(ClientCredentials cc) : base (cc, new DataManagementScope())
        {
            _client = new DMClient(Authenticator);
            _requestBuilder = new DMRequestBuilder();
            _dataBuilder = new DMDataBuilder();
        }

        /// <summary>
        /// Creates an instance of <see cref="BucketsApi"/>. Mainly used by Dependency Injection
        /// </summary>
        /// <param name="client">The DM Client to be used on executing requests</param>
        /// <param name="requestBuilder">The request builder instance</param>
        /// <param name="dataBuilder">The data builder instance</param>
        public BucketsApi(DMClient client, DMRequestBuilder requestBuilder, DMDataBuilder dataBuilder)
        {
            _client = client;
            _requestBuilder = requestBuilder;
            _dataBuilder = dataBuilder;
        }

        /// <summary>
        /// Gets available buckets from Autodesk Platform Services
        /// </summary>
        /// <returns>An instance of <see cref="BucketList"/> containing the available buckets</returns>
        public BucketList GetBuckets()
        {
            var r = _requestBuilder
                .UseGetBuckets()
                .Build();

            return _client.Execute<BucketList>(r);
        }

        /// <summary>
        /// Creates new bucket on Autodesk Platform Services
        /// </summary>
        /// <param name="bucketKey">Bucket key</param>
        /// <param name="policyKey">The retention policy key. <see href="https://aps.autodesk.com/en/docs/data/v2/developers_guide/retention-policy/"/></param>
        /// <returns>The instance of the <see cref="Bucket"/> created</returns>
        public Bucket PostBucket(string bucketKey, BucketPolicyKey policyKey)
        {
            var data = _dataBuilder
                .UseBucket(bucketKey, policyKey)
                .Build();

            var r = _requestBuilder
                .UsePostBucket(data)
                .Build();

            return _client.Execute<Bucket>(r);
        }

        /// <summary>
        /// Deletes a bucket by its key
        /// </summary>
        /// <param name="bucketKey">Key of the bucket to be deleted</param>
        public void DeleteBucket(string bucketKey)
        {
            var r = _requestBuilder
                .UseDeleteBucket(bucketKey)
                .Build();

            _client.Execute(r);
        }

    }
}
