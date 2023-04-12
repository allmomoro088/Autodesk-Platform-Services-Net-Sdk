using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    public class JsonapiBase
    {
        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
    }
}
