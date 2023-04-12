using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autodesk.PlatformServices.DM
{
    internal class StorageLocationCreationRelationships
    {
        [JsonProperty("target")]
        public DMRelationshipBase Target { get; set; }
    }
}
