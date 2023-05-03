using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.ACC
{
    public class IssuesPagination
    {
        public Pagination Pagination { get; set; }
        public List<Issue> Results { get; set; }
    }
}
