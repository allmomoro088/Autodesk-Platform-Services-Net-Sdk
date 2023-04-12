using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreationVersion
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "versions";
        [JsonProperty("id")]
        public string Id { get; set; } = "1";
        [JsonProperty("attributes")]
        public VersionCreationAttributes Attributes { get; set; }
        [JsonProperty("relationships")]
        public ItemCreationVersionRelationships Relationships { get; set; }

        public ItemCreationVersion(string fileName, string storageId)
        {
            Attributes = new VersionCreationAttributes
            {
                Name = fileName
            };
            Relationships = new ItemCreationVersionRelationships
            {
                Storage = new DMRelationshipBase
                {
                    Data = new RelationshipData
                    {
                        Type = "objects",
                        Id = storageId
                    }
                }
            };
        }
    }
}
