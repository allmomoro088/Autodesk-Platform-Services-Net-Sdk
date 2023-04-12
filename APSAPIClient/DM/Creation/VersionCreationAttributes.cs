using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class VersionCreationAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("extension")]
        public VersionCreationExtension Extension { get; set; } = new VersionCreationExtension();
    }
}
