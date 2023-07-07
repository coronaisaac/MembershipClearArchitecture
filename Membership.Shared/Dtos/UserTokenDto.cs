using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Shared.Dtos
{
    public class UserTokenDto
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public UserTokenDto(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

     
    }
}
