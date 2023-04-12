using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    public class TokenBase
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; }
        public int Expires_in { get; set; }
        public DateTime ObtainedAt { get; set; }

        public DateTime ExpirationDate
        {
            get
            {
                return ObtainedAt.AddSeconds(Expires_in);
            }
        }

        public TokenBase()
        {
            ObtainedAt = DateTime.Now;
        }
    }
}
