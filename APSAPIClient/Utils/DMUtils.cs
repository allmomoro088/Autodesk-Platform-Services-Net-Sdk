using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Web;

namespace Autodesk.PlatformServices.Utils
{
    internal static class DMUtils
    {
        internal static string TreatId(this string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id");
            string r = "";
            if (id.StartsWith("b."))
                r = id.Replace("b.", "");
            else
                r = id;
            return r;
        }

        internal static string UrlEncode(this string source)
        {
            return HttpUtility.UrlEncode(source);
        }
    }
}
