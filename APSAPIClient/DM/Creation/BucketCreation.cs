using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class BucketCreation
    {
        [JsonProperty("bucketKey")]
        public string BucketKey { get; set;}
        [JsonProperty("policyKey")]
        public string PolicyKey { get; set; }
    }
}
