using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// The implementation for IScope
    /// Contains: bucket:read, bucket:create, bucket:update, bucket:delete
    /// </summary>
    public class BucketScope : IScope
    {
        /// <inheritdoc/>
        public Scope GetScope()
        {
            return Scope.Bucket_Read
                | Scope.Bucket_Create
                | Scope.Bucket_Update
                | Scope.Bucket_Delete;
        }
    }
}
