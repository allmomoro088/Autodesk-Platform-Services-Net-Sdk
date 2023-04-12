using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class VersionCreationExtension
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "versions:autodesk.bim360:File";
        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
    }
}
