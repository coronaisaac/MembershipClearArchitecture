using Membership.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Presenters
{
    internal class RefreshTokenPresenter : IRefreshTokenOutput
    {
        readonly IAccessTokenService accessTokenService;
        readonly IRefreshTokenService refreshTokenService;

        public RefreshTokenPresenter(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService)
        {
            this.accessTokenService = accessTokenService;
            this.refreshTokenService = refreshTokenService;
        }
        public UserTokenDto UserToken { get; private set; }

        public UserTokenDto UserTokenDto => throw new NotImplementedException();

        public async Task HandleAccesTokenAsync(string accessToken)
        {
            string accesToken = await accessTokenService.RotateAccessTokenAsync(accessToken);
            string refreshToken = await refreshTokenService.GetRefreshTokenForAccesTokenAsync(accesToken);
            UserToken = new UserTokenDto(accesToken, refreshToken);
        }

        
    }
}
