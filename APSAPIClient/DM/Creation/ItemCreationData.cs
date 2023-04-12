using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreationData
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "items";
        [JsonProperty("attributes")]
        public ItemCreationAttributes Attributes { get; set; }
        [JsonProperty("relationships")]
        public ItemCreationRelationships Relationships { get; set; }

        public ItemCreationData(string fileName, string parentId)
        {
            Attributes = new ItemCreationAttributes
            {
                DisplayName = fileName
            };
            Relationships = new ItemCreationRelationships
            {
                Tip = new DMRelationshipBase
                {
                    Data = new RelationshipData
                    {
                        Type = "versions",
                        Id = "1"
                    }
                },
                Parent = new DMRelationshipBase
                {
                    Data = new RelationshipData
                    {
                        Type = "folders",
                        Id = parentId
                    }
                }
            };
        }
    }
}
