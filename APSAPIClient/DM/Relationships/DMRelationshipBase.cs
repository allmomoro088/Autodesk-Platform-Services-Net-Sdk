using Autodesk.PlatformServices.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class DMRelationshipBase
    {
        [JsonProperty("data")]
        public RelationshipData Data { get; set; }
    }
}
