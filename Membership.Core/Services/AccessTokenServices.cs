using Membership.Abstractions.Entities;
using Membership.Abstractions.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Membership.Core.Services
{
    internal class AccessTokenServices : IAccessTokenService
    {
        readonly JwtOptions jwtOptions;

        public AccessTokenServices(IOptions<JwtOptions> jwtOptions)
        {
            this.jwtOptions = jwtOptions.Value;
        }
        public async Task<string> GetNewUserAccessTokenAsync(UserEntity userEntity)
         =>   await Task.FromResult(GetAccesToken(GetUserClaims(userEntity)));
        public async Task<string> RotateAccessTokenAsync(string accessTokenToRotate)
         =>   await Task.FromResult(GetAccesToken(GetUserClaimsFromAccessToken(accessTokenToRotate)));
        string GetAccesToken(List<Claim> userClaims)
        {
            var Key = Encoding.UTF8.GetBytes(jwtOptions.SecurityKey);
            var secret = new SymmetricSecurityKey(Key);
            var signingCredentials = new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer:jwtOptions.ValidIssuer, 
                audience:jwtOptions.ValidAudience, 
                claims:userClaims, 
                expires:DateTime.Now.AddMinutes(jwtOptions.ExpireInMinutes),
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        static List<Claim> GetUserClaims(UserEntity userEntity) =>
            new()
            {
                new Claim(ClaimTypes.Name,userEntity.Email),
                new Claim("FullName",userEntity.FullName)
            };
        static List<Claim> GetUserClaimsFromAccessToken(string accessToken) =>
            new JwtSecurityTokenHandler ()
                .ReadJwtToken(accessToken)
                .Claims
                .ToList();
    }
}
