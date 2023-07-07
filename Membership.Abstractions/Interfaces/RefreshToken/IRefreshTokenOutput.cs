using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.RefreshToken
{
    public interface IRefreshTokenOutput
    {
        UserTokenDto UserTokenDto { get; }
        Task HandleAccesTokenAsync(string accessToken);
    }
}
