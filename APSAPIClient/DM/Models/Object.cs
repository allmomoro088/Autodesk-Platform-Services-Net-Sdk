using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    public class Object
    {
        public string BucketKey { get; set; }
        public string ObjectId { get; set; }
        public string ObjectKey { get; set; }
        public long? Size { get; set; }
        public string ContentType { get; set; }
        public string Location { get; set; }
    }
}
