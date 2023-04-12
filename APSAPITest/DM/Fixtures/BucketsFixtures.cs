using Autodesk.PlatformServices.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.DM.Fixtures
{
    internal static class BucketsFixtures
    {
        internal static Bucket BucketRight() =>
            new Bucket
            {
                BucketKey = "bkey",
                BucketOwner = "bowner",
                CreatedDate = 1000,
            };

        internal static BucketList RightBucketList() =>
            new BucketList
            {
                Items = new List<Bucket>
                {
                    BucketRight()
                }
            };

        internal static string RightBucketKey() =>
            "bucket";

        internal static string RightObjectKey() =>
            "object";
    }
}
