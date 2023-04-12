using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreationRelationships
    {
        [JsonProperty("tip")]
        public DMRelationshipBase Tip { get; set; }
        [JsonProperty("parent")]
        public DMRelationshipBase Parent { get; set; }
    }
}
