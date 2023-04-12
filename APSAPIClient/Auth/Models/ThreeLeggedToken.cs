using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    public class ThreeLeggedToken : TokenBase
    {
        public string Refresh_Token { get; set; }
    }
}
