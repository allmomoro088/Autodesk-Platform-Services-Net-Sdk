using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Bucket
    {
        public string BucketKey { get; set; }
        public string BucketOwner { get; set; }
        public long CreatedDate { get; set; }
        public Dictionary<string, string> Permissions { get; set; } = new Dictionary<string, string>();
        public string PolicyKey { get; set; }
    }
}
