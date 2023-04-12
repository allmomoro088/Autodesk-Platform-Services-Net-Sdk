using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Base
{
    public abstract class AttributesBase
    {
        public string Name { get; set; }
        public ExtensionBase Extension { get; set; }
    }
}
