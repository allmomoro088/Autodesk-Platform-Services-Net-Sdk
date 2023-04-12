using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class StorageLocationCreationAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
