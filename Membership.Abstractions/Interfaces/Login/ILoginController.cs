using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.Login
{
    public interface ILoginController
    {
        Task<UserTokenDto> LoginAsync(UserCredentialsDto userCredentialsDto);
    }
}
