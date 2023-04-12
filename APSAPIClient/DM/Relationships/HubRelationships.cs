using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class HubRelationships : RelationshipsBase
    {
        public DMRelationshipWithLinksRelatedOnly Projects { get; set; }
        public DMRelationshipBase PimCollection { get; set; }
    }
}
