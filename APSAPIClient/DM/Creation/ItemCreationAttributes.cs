using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ItemCreationAttributes
    {
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("extension")]
        public ItemCreationExtension Extension { get; set; } = new ItemCreationExtension();
    }
}
