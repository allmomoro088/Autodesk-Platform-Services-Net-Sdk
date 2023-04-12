using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth
{
    /// <summary>
    /// The interface used to store tokens obtained via Two Legged Authentication flow
    /// </summary>
    public interface I2LOStorage
    {
        /// <summary>
        /// Used by <see cref="Authenticator"/> to store the token
        /// </summary>
        /// <param name="t">Instance of 2 legged token being stored</param>
        void Store(TwoLeggedToken t);

        /// <summary>
        /// Used by <see cref="Authenticator"/> to obtain the stored 2 legged token
        /// </summary>
        /// <returns></returns>
        TwoLeggedToken Obtain();
    }
}
