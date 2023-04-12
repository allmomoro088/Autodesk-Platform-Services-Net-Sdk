using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class ItemRelationships
    {
        public DMRelationshipWithLinksRelated Tip { get; set; }
        public DMRelationshipWithLinksRelatedOnly Versions { get; set; }
        public DMRelationshipWithLinksRelated Parent { get; set; }
        public DMRelationshipLinksSelfAndRelated Refs { get; set; }
        public DMRelationshipWithLinksSelfOnly Links { get; set; }
    }
}
