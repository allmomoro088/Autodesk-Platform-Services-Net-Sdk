using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autodesk.PlatformServices.DM
{
    internal class FolderCreationRelationships
    {
        [JsonProperty("parent")]
        public DMRelationshipBase Parent { get; set; }
    }
}
