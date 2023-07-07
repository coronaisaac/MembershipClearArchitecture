namespace Membership.Abstractions.Interfaces.Services
{
    public interface IRefreshTokenService
    {
        Task<string> GetRefreshTokenForAccesTokenAsync(string accesToken);
        Task<string> DeleteRefreshTokenAsync(string refreshToken);
        Task ThrowIfUnableToRotateRefreshTokenAsync(string refreshToken, string accessToken);
        

    }
}
