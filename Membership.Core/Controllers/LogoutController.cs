using Membership.Abstractions.Interfaces.Logout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Controllers
{
    internal class LogoutController : ILogoutController
    {
        readonly ILogoutInputPort loginInputPort;
        public LogoutController(ILogoutInputPort loginInputPort)
        {
            this.loginInputPort = loginInputPort;
        }

        public async Task LogoutAsync(UserTokenDto userTokenDto)
        {
            await loginInputPort.LogoutAsync(userTokenDto);
        }
    }
}
