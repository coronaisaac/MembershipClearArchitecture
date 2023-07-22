namespace Membership.Core.Controllers;

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
