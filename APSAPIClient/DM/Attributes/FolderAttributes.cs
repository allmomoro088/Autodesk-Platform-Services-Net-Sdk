using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class FolderAttributes : AttributesBase
    {
        public string DisplayName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public string LastModifiedUserName { get; set; }
        public DateTime? LastModifiedTimeRollup { get; set; }
        public string Path { get; set; }
        public int? ObjectCount { get; set; }
        public new FolderExtension Extension { get; set; }
    }
}
