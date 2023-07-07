using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Exceptions
{
    public class RefreshTokenCompromiseException : Exception
    {
        public RefreshTokenCompromiseException()
        {
        }

        public RefreshTokenCompromiseException(string? message) : base(message)
        {
        }

        public RefreshTokenCompromiseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
