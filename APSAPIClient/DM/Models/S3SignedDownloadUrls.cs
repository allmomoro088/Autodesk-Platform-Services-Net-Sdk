using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class S3SignedDownloadUrls
    {
        public string Status { get; set; }
        public Dictionary<string, string> Urls { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
        public long? Size { get; set; }
        public string SHA1 { get; set; }
    }
}
