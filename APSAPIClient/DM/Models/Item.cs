using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Item
    {
        public string Id { get; set; }
        public ItemAttributes Attributes { get; set; }
        public LinksSelfWebView Links { get; set; }
        public ItemRelationships Relationships { get; set; }

    }
}
