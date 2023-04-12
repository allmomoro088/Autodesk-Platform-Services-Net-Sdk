using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class FolderCreationExtension
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "folders:autodesk.bim360:Folder";
        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
    }
}
