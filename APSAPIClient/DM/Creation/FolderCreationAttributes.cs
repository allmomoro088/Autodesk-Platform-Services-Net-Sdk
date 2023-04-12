using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class FolderCreationAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("extension")]
        public FolderCreationExtension Extension { get; set; } = new FolderCreationExtension();
    }
}
