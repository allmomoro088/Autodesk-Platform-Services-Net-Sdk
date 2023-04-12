using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.PlatformServices.Base;

namespace Autodesk.PlatformServices.DM
{
    /// <summary>
    /// The base class for most Data Management APIs response
    /// </summary>
    /// <typeparam name="T">Type of data brought by the API in the response</typeparam>
    public class DMApiResponseBase<T>
    {
        public JsonapiBase Jsonapi { get; set; }
        public LinksSelf Links { get; set; }
        public T Data { get; set; }
    }
}
