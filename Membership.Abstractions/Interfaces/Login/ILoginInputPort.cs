using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Abstractions.Interfaces.Login
{
    public interface ILoginInputPort
    {
        Task Login(UserCredentialsDto userCredentialsDto);
    }
}
