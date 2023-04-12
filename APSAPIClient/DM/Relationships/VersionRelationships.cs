using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class VersionRelationships
    {
        public DMRelationshipWithLinksRelated Item { get; set; }
        public DMRelationshipWithLinksSelfOnly Links { get; set; }
        public DMRelationshipLinksSelfAndRelated Refs { get; set; }
        public DMRelationshipWithLinksRelatedOnly DownloadFormats { get; set; }
        public DMRelationshipWithMeta Derivatives { get; set; }
        public DMRelationshipWithMeta Thumbnails { get; set; }
        public DMRelationshipWithMeta Storage { get; set; }
    }
}
