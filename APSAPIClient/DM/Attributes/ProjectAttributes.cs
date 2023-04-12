using Autodesk.PlatformServices.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class ProjectAttributes : AttributesBase
    {
        public List<string> Scopes { get; set; }
        public new ProjectExtension Extension { get; set; }
    }
}
