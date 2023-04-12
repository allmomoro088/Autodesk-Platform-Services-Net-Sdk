using Autodesk.PlatformServices.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Utils
{
    internal static class ScopeUtils
    {
        internal static string Stringfy(this Scope scope)
        {
            string s = "";
            foreach(Scope f in Enum.GetValues(typeof(Scope)))
            {
                if (scope.HasFlag(f))
                {
                    if (string.IsNullOrEmpty(s))
                    {
                        s += f.ToString().Replace('_', ':');
                    }
                    else
                    {
                        s += $" {f.ToString().Replace('_', ':')}";
                    }
                }
            }
            return s.ToLower();
        }

        internal static Scope ToScope(this string s)
        {
            var splitted = s.Split(',');
            Scope scope = 0;
            foreach (var stringScope in splitted)
            {
                scope |= (Scope)Enum.Parse(typeof(Scope), stringScope, true);
            }
            return scope;
        }
    }
}
