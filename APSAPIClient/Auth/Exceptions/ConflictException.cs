using System;
using System.Collections.Generic;
using System.Text;

namespace Autodesk.PlatformServices.Auth.Exceptions
{
    /// <summary>
    /// Represents the conflict return of an API call
    /// </summary>
    public class ConflictException : Exception
    {
        public ConflictException()
        {

        }
        public ConflictException(string message) : base(message)
        {

        }
    }
}
