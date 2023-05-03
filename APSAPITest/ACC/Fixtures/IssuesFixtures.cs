using Autodesk.PlatformServices.ACC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSAPITest.ACC.Fixtures
{
    internal static class IssuesFixtures
    {
        internal static Issue RightIssue() =>
            new Issue();
        internal static IssuesPagination RightIssuesPagination() =>
            new IssuesPagination
            {
                Results = new List<Issue>()
                {
                    RightIssue()
                }
            };
    }
}
