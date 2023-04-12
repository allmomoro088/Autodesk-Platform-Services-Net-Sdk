using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class FolderRelationships : RelationshipsBase
    {
        public DMRelationshipWithLinksRelated Parent { get; set; }
        public DMRelationshipLinksSelfAndRelated Refs { get; set; }
        public DMRelationshipWithLinksSelfOnly Links { get; set; }
        public DMRelationshipWithLinksRelated Contents { get; set; }
    }
}
