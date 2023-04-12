using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreationVersionRelationships
    {
        [JsonProperty("storage")]
        public DMRelationshipBase Storage { get; set; }
    }
}
