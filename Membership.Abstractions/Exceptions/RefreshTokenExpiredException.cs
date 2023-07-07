using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Exceptions
{
    public class RefreshTokenExpiredException : Exception
    {
        public RefreshTokenExpiredException()
        {
        }

        public RefreshTokenExpiredException(string? message) : base(message)
        {
        }

        public RefreshTokenExpiredException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

  
    }
}
