using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class VersionCreationData
    {
        public string Type { get; set; } = "versions";
        public VersionCreationAttributes Attributes { get; set; }
        public VersionCreationRelationships Relationships { get; set; }

        public VersionCreationData(string fileName, string itemId, string storageId)
        {
            Attributes = new VersionCreationAttributes
            {
                Name = fileName
            };
            Relationships = new VersionCreationRelationships
            {
                Item = new DMRelationshipBase
                {
                    Data = new RelationshipData
                    {
                        Type = "items",
                        Id = itemId
                    }
                },
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
