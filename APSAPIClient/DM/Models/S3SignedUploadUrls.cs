using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class S3SignedUploadUrls
    {
        public string UploadKey { get; set; }
        public DateTime? UploadExpiration { get; set; }
        public DateTime? UrlsExpiration { get; set; }
        public List<string> Urls { get; set; } = new List<string>();
    }
}
