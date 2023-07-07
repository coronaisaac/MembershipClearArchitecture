using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Exceptions
{
    public class RefreshTokenNotFoundException : Exception
    {
        public RefreshTokenNotFoundException()
        {
        }

        public RefreshTokenNotFoundException(string? message) : base(message)
        {
        }

        public RefreshTokenNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

       
    }
}
