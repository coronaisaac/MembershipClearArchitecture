using Membership.Abstractions.Interfaces.Logout;
using Membership.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Interactors
{
    internal class LogoutInteractor : ILogoutInputPort
    {
        readonly IRefreshTokenService refreshTokenService;

        public LogoutInteractor(IRefreshTokenService refreshTokenService)
        {
            this.refreshTokenService = refreshTokenService;
        }
        public async Task LogoutAsync(UserTokenDto UserTokeDto)
        {
            await refreshTokenService.DeleteRefreshTokenAsync(UserTokeDto.RefreshToken);
        }
    }
}
