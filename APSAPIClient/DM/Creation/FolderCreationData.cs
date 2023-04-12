using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class FolderCreationData 
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "folders";
        [JsonProperty("attributes")]
        public FolderCreationAttributes Attributes { get; set; }
        [JsonProperty("relationships")]
        public FolderCreationRelationships Relationships { get; set; }

        public FolderCreationData(string folderName, string parentId)
        {
            Attributes = new FolderCreationAttributes
            {
                Name = folderName,
            };

            Relationships = new FolderCreationRelationships
            {
                Parent = new DMRelationshipBase
                {
                    Data = new RelationshipData
                    {
                        Id = parentId,
                        Type = "folders"
                    }
                }
            };
        }
    }
}
