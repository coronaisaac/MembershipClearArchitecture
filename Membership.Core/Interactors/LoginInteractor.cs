namespace Membership.Core.Interactors
{
    internal class LoginInteractor : ILoginInputPort
    {
        readonly IUserManagerService userManagerService;
        readonly IValidator<UserCredentialsDto> validator;
        readonly ILoginOutputPort outputPort;

        public LoginInteractor(IUserManagerService userManagerService, IValidator<UserCredentialsDto> validator, ILoginOutputPort outputPort)
        {
            this.userManagerService = userManagerService;
            this.validator = validator;
            this.outputPort = outputPort;
        }

        public async Task Login(UserCredentialsDto userCredentialsDto)
        {
            var validateErrors = validator.Validate(userCredentialsDto);
            if(validateErrors !=null && validateErrors.Any()) 
            {
                throw new LoginUserException();
            }

            var user =await  userManagerService.ThrowIfUnableToGetUserByCredentialsAsync(userCredentialsDto);
            await outputPort.HandleUserEntityAsync(user);
        }
    }
}
