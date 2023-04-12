using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// An abstraction for building body data in json for Data Management APIs
    /// </summary>
    public class DMDataBuilder
    {
        object _data;

        /// <summary>
        /// Defines that data to be built is for creating a Storage Location in a Project
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="parentId">Folder id where the file will be uploaded</param>
        /// <returns>This <see cref="DMDataBuilder"/> instance</returns>
        public virtual DMDataBuilder UseStorageLocation(string fileName, string parentId)
        {
            _data = new StorageLocationCreation
            {
                Data = new StorageLocationCreationData(fileName, parentId)
            };
            return this;
        }

        /// <summary>
        /// Defines that data to be built is for creating a Folder in a Project
        /// </summary>
        /// <param name="folderName">Folder name to be created</param>
        /// <param name="parentId">Parent folder id where the folder will be created on</param>
        /// <returns>This <see cref="DMDataBuilder"/> instance</returns>
        public virtual DMDataBuilder UseFolder(string folderName, string parentId)
        {
            _data = new FolderCreation
            {
                Data = new FolderCreationData(folderName, parentId)
            };
            return this;
        }

        /// <summary>
        /// Defines that data to be built is for creating an Item in a Project
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="parentId">Folder id where the file will be shown</param>
        /// <param name="storageId">The storage id created in order to upload this file</param>
        /// <returns>This <see cref="DMDataBuilder"/> instance</returns>
        public virtual DMDataBuilder UseItem(string fileName, string parentId, string storageId)
        {
            _data = new ItemCreation
            {
                Data = new ItemCreationData(fileName, parentId),
                Included = new List<ItemCreationVersion> { new ItemCreationVersion(fileName, storageId) }
            };
            return this;
        }

        /// <summary>
        /// Defines that data to be built is for creating a new Version of an Item in a Project
        /// </summary>
        /// <param name="fileName">File name for the new version (Should be the same as before)</param>
        /// <param name="itemId">Item id</param>
        /// <param name="storageId">The storage id created in order to upload this file</param>
        /// <returns>This <see cref="DMDataBuilder"/> instance</returns>
        public DMDataBuilder UseVersion(string fileName, string itemId, string storageId)
        {
            _data = new VersionCreation
            {
                Data = new VersionCreationData(fileName, itemId, storageId)
            };
            return this;
        }

        /// <summary>
        /// Defines that data to be built is for finishing an Object upload
        /// </summary>
        /// <param name="uploadKey">The upload key provided together with Upload Urls</param>
        /// <returns>This <see cref="DMDataBuilder"/> instance</returns>
        public DMDataBuilder UseObject(string uploadKey)
        {
            _data = new ObjectCreation()
            {
                UploadKey = uploadKey
            };
            return this;
        }

        /// <summary>
        /// Defines that data to be built is for creating a new Bucket
        /// </summary>
        /// <param name="bucketKey">Bucket Key</param>
        /// <param name="policyKey">Storage policy key</param>
        /// <returns></returns>
        public virtual DMDataBuilder UseBucket(string bucketKey, BucketPolicyKey policyKey)
        {
            _data = new BucketCreation()
            {
                BucketKey = bucketKey,
                PolicyKey = policyKey.ToString().ToLower()
            };
            return this;
        }

        /// <summary>
        /// Builds data to be sent in requests. Serializes data to json
        /// </summary>
        /// <returns>A <see cref="String"/> of the serialized data to json</returns>
        public virtual string Build()
        {

            var result = JsonConvert.SerializeObject(_data);
            ClearInputs();
            return result;
        }

        private void ClearInputs()
        {
            _data = null;
        }
    }
}
