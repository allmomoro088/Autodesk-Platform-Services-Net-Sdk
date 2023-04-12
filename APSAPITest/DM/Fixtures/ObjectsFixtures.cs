using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class ObjectsFixtures
    {
        internal static S3SignedDownloadUrls RightDownloadUrls() =>
            new S3SignedDownloadUrls
            {
                Urls = new Dictionary<string, string>
                {
                    { "url1", "http://url1.com.br" },
                    { "url2", "http://url2.com.br" }
                }
            };

        internal static S3SignedUploadUrls RightUploadUrls() =>
            new S3SignedUploadUrls
            {
                Urls = new List<string>
                {
                    "https://url1.com.br",
                    "https://url2.com.br",
                    "https://url3.com.br"
                },
                UploadKey = UploadKey()
            };

        internal static string UploadKey() =>
            "uploadkey1";

        internal static long MB2() =>
            2 * 1024 * 1024;

        internal static long MB50() =>
            50 * 1024 * 1024;

        internal static long MB500() =>
            500 * 1024 * 1024;

        internal static long GB1() =>
            1024 * 1024 * 1024;

        internal static long GB10()
        {
            long gb = 1024 * 1024 * 1024;
            return 10 * gb; 
        }
    }
}
