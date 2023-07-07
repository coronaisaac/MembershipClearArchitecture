using Membership.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Presenters
{
    internal class LoginPresenter : ILoginOutputPort
    {
        readonly IAccessTokenService accessTokenService;
        readonly IRefreshTokenService refreshTokenService;

        public LoginPresenter(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService)
        {
            this.accessTokenService = accessTokenService;
            this.refreshTokenService = refreshTokenService;
        }
        public UserTokenDto UserToken { get; private set; } 
        public async Task HandleUserEntityAsync(UserEntity userEntity)
        {
            string accesToken = await accessTokenService.GetNewUserAccessTokenAsync(userEntity);
            string refreshToken = await refreshTokenService.GetRefreshTokenForAccesTokenAsync(accesToken);
            UserToken = new UserTokenDto(accesToken, refreshToken);
        }
    }
}
