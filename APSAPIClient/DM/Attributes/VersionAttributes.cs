using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class VersionAttributes : AttributesBase
    {
        public string DisplayName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string  LastModifiedUserId { get; set; }
        public string LastModifiedUserName { get; set;}
        public int? VersionNumber { get; set; }
        public string MimeType { get; set; }
        public string FileType { get; set; }
        public long? StorageSize { get; set; }
        public new VersionExtension Extension { get; set; }
    }
}
