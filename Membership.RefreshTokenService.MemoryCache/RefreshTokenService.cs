namespace Membership.RefreshTokenService.MemoryCache
{
    internal class RefreshTokenService : IRefreshTokenService
    {
        readonly JwtOptions jwtOptions;
        readonly IMemoryCache memoryCache;

        public RefreshTokenService(IOptions<JwtOptions> jwtOptions , IMemoryCache memoryCache)
        {
            this.jwtOptions = jwtOptions.Value;
            this.memoryCache = memoryCache;
        }

        public Task<string> DeleteRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRefreshTokenForAccesTokenAsync(string accessToken)
        {
            var refrToken = GenerateToken();
            RefreshTokenInfo refreshTokenInfo = new(accessToken,
                DateTime.UtcNow.AddMinutes(jwtOptions.RefreshTokenExpireInMinutes));
            memoryCache.Set(refrToken, refreshTokenInfo, DateTime.Now.AddMinutes(jwtOptions.RefreshTokenExpireInMinutes));

            return Task.FromResult(refrToken);
        }

        public async Task ThrowIfUnableToRotateRefreshTokenAsync(string refreshToken, string accessToken)
        {
            if (memoryCache.TryGetValue(refreshToken, out RefreshTokenInfo refreshTokenInfo))
            {
                memoryCache.Remove(refreshToken);
                if (refreshTokenInfo.AccessToken != accessToken)
                    throw new RefreshTokenCompromiseException();
                if (refreshTokenInfo.RefreshTokenExpiresAt < DateTime.UtcNow)
                    throw new RefreshTokenExpiredException();

            }
            else
            {
                throw new RefreshTokenNotFoundException();
            }
            await Task.CompletedTask;
        }
        static string GenerateToken()
        {
            //Cada Caracter Base64 es de 6 bits
            //3 bytes generan 4 caracteres base64
            var buffer = new Byte[75];
            using var Rng = RandomNumberGenerator.Create();
            Rng.GetNonZeroBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}
