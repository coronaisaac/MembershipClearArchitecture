using Membership.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.Logout
{
    public interface ILogoutInputPort
    {
        Task LogoutAsync(UserTokenDto UserTokeDto);
    }
}
