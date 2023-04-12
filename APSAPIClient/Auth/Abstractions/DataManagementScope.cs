using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Abstractions
{
    /// <summary>
    /// The implementation for IScope
    /// Contains: data:read, data:write, data:create, data:search, bucket:read, bucket:create, bucket:update, bucket:delete
    /// </summary>
    public class DataManagementScope : IScope
    {
        public Scope GetScope()
        {

            return Scope.Data_Read
                | Scope.Data_Write
                | Scope.Data_Create
                | Scope.Data_Search
                | Scope.Bucket_Read
                | Scope.Bucket_Create
                | Scope.Bucket_Update
                | Scope.Bucket_Delete;
        }
    }
}
