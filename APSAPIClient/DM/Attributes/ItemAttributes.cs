using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class ItemAttributes
    {
        public string DisplayName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedUserId { get; set; }
        public string LastModifiedUserName { get; set;}
        public bool? Hidden { get; set; }
        public bool? Reserved { get; set; }
        public ItemExtension Extension { get; set; }
    }
}
