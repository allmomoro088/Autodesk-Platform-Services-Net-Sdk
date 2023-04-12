using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Abstractions
{
    /// <summary>
    /// The interface used to get the token scope that should be used
    /// </summary>
    public interface IScope
    {
        /// <summary>
        /// Gets the token scope declared
        /// </summary>
        /// <returns>A enum with flags of the scopes for token</returns>
        Scope GetScope();
    }
}
