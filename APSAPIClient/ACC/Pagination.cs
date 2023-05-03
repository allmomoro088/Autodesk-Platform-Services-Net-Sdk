using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class Pagination
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResults { get; set; }
    }
}
