using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Controllers
{
    internal class RegisterController : IRegisterController
    {
        readonly IRegisterInputPort registerInputPort;

        public RegisterController(IRegisterInputPort registerInputPort)
        {
            this.registerInputPort = registerInputPort;
        }

        public Task RegisterAsync(UserDto userDto)=>
            registerInputPort.RegisterAsync(userDto);
        
    }
}
