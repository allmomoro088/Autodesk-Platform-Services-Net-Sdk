using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    internal class ObjectCreation
    {
        [JsonProperty("uploadKey")]
        public string UploadKey { get; set; }
    }
}
