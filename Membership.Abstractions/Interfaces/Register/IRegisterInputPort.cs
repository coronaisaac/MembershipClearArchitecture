using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.Register
{
    public interface IRegisterInputPort
    {
        Task RegisterAsync(UserDto userDto);
    }
}
