using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.PlatformServices.Utils
{
    public static class ObjectsUtils
    {
        public static bool ParseIdToKeys(this string id, out string bucketKey, out string objectKey)
        {
            try
            {
                var splittedId = id.Split('/');
                objectKey = splittedId[1];

                var splittedUrn = splittedId[0].Split(':');
                bucketKey = splittedUrn.Last();

                return true;
            }
            catch
            {
                bucketKey = null;
                objectKey = null;
                return false;
            }
        }
    }
}
