using Membership.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Controllers
{
    internal class LoginController : ILoginController
    {
        readonly ILoginInputPort InputPort;
        readonly ILoginOutputPort OutputPort;
        public LoginController(ILoginInputPort loginInputPort, ILoginOutputPort loginOutputPort)
        {
            this.InputPort = loginInputPort;
            this.OutputPort = loginOutputPort;
        }

        public async Task<UserTokenDto> LoginAsync(UserCredentialsDto userCredentialsDto)
        {
            await InputPort.Login(userCredentialsDto);
            return OutputPort.UserToken;
        }
    }
}
