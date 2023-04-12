using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    internal abstract class CreationDataBase
    {
        [JsonProperty("jsonapi")]
        public JsonapiBase JsonApi { get; set; } = new JsonapiBase();
    }
}
