using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class LinksSelfPaginated : LinksSelf
    {
        public HrefRelation First { get; set; }
        public HrefRelation Prev { get; set; }
        public HrefRelation Next { get; set; }
    }
}
