namespace Membership.Core.Interactors
{
    internal class RefreshTokenInteractor : IRefreshTokenInputPort
    {
        readonly IRefreshTokenService refreshTokenService;
        readonly IRefreshTokenOutput refreshTokenOutput;

        public RefreshTokenInteractor(IRefreshTokenService refreshTokenService, IRefreshTokenOutput refreshTokenOutput)
        {
            this.refreshTokenService = refreshTokenService;
            this.refreshTokenOutput = refreshTokenOutput;
        }

        public async Task RefreshTokenAsync(UserTokenDto userTokenDto)
        {
            await refreshTokenService.ThrowIfUnableToRotateRefreshTokenAsync(userTokenDto.RefreshToken,userTokenDto.AccessToken);
            await refreshTokenOutput.HandleAccesTokenAsync(userTokenDto.AccessToken);
        }
    }
}
