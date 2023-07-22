namespace Membership.UserManagerService.AspNetIdentity.Services;
internal partial class UserManagerService
{
    public async Task<IEnumerable<MembershipError>> RegisterExternalUserAsync(ExternalUserEntity externalUserEntity) 
    {
        IEnumerable<MembershipError>? errors = null;
        IdentityResult? identityResult = null;
        bool UserExist = false;
        var existingUser = await UserManager.FindByEmailAsync(externalUserEntity.Email);
        if(existingUser == null) 
        {
            existingUser = new()
            {
                UserName = externalUserEntity.Email,
                Email = externalUserEntity.Email,
                FirstName = externalUserEntity.FirstName,
                LastName = externalUserEntity.LastName
            };
        }
        else
        {
            UserExist = true;
        }
        if (UserExist)
        {
            identityResult = await UserManager.AddLoginAsync(existingUser, new UserLoginInfo(externalUserEntity.LoginProvider, externalUserEntity.ProviderUserID, externalUserEntity.LoginProvider)); 
        }
        if(identityResult!=null && !identityResult.Succeeded)
        {
            errors = ErrorsHandler.Handle(identityResult.Errors);
        }
        identityResult = await UserManager.CreateAsync(existingUser);
        UserExist = identityResult.Succeeded;
        return errors;
    }
    public async Task<UserEntity> GetUserByExternalCredentialsAsync(ExternalUserCredentials userCredentials)
    {
        UserEntity FoundUser = default;
        var User = await UserManager.FindByLoginAsync(userCredentials.LoginProvider,userCredentials.ProviderUser);
        if (User != null )
        {
            FoundUser = new UserEntity(User.UserName,
                User.FirstName, User.LastName);
        }
        return FoundUser;
    }
}
