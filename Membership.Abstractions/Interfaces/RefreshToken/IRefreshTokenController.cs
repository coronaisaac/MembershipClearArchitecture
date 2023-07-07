using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.RefreshToken
{
    public interface IRefreshTokenController
    {
        Task<UserTokenDto> RefreshTokenAsync(UserTokenDto userTokenDto);
    }
}
