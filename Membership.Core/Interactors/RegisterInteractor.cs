namespace Membership.Core.Interactors
{
    internal class RegisterInteractor : IRegisterInputPort
    {
        readonly IUserManagerService userManagerService;
        readonly IValidator<UserDto> validator;

        public RegisterInteractor(IUserManagerService userManagerService, IValidator<UserDto> validator)
        {
            this.userManagerService = userManagerService;
            this.validator = validator;
        }

        public async Task RegisterAsync(UserDto userDto)
        {
            var validationErrors = validator.Validate(userDto);
            if(validationErrors !=null && validationErrors.Any())
            {
                throw new RegisterUserException(validationErrors);
            }
            await userManagerService.ThrowIfUnableToRegisterUserAsync(userDto);
        }
    }
}
