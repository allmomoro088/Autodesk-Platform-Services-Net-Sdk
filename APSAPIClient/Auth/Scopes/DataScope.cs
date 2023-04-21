using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// The implementation for IScope
    /// Contains: data:read, data:write, data:create, data:search
    /// </summary>
    public class DataScope : IScope
    {
        /// <inheritdoc/>
        public Scope GetScope()
        {
            return Scope.Data_Read
                | Scope.Data_Write
                | Scope.Data_Create
                | Scope.Data_Search;
        }
    }
}
