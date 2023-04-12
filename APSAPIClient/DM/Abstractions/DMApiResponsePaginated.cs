using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// The base class for Data Management APIs paginated responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DMApiResponsePaginated<T> : DMApiResponseBase<T>
    {
        public new LinksSelfPaginated Links { get; set; }
    }
}
