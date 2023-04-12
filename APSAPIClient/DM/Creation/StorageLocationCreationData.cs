using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class StorageLocationCreationData
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "objects";
        [JsonProperty("attributes")]
        public StorageLocationCreationAttributes Attributes { get; set; }
        [JsonProperty("relationships")]
        public StorageLocationCreationRelationships Relationships { get; set; }


        public StorageLocationCreationData(string fileName, string folderId)
        {
            Attributes = new StorageLocationCreationAttributes
            {
                Name = fileName
            };

            Relationships = new StorageLocationCreationRelationships
            {
                Target = new DMRelationshipBase()
                {
                    Data = new RelationshipData
                    {
                        Type = "folders",
                        Id = folderId
                    }
                }
            };
        }
    }
}
