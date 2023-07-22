namespace Membership.UserManagerService.AspNetIdentity.Services;

internal partial class UserManagerService : IUserManagerService
{
    readonly UserManagerErrorHandler ErrorsHandler;

    readonly UserManager<User> UserManager;
    public UserManagerService(UserManagerErrorHandler handler, UserManager<User> userManager)
    {
        this.ErrorsHandler = handler;
        this.UserManager = userManager;
    }
}
