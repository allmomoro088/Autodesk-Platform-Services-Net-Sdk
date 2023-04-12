using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class DMRelationshipWithMeta : DMRelationshipBase
    {
        public MetaLink Meta { get; set; }
    }
}
