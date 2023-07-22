namespace Membership.UserManagerService.AspNetIdentity.Services;

public class UserManagerErrorHandler
{
    readonly IMembershipMessageLocalizer localizer;

    public UserManagerErrorHandler(IMembershipMessageLocalizer localizer)
    {
        this.localizer = localizer;
    }
    public IEnumerable<MembershipError> Handle(IEnumerable<IdentityError> errors)
    {
        List<MembershipError> Errors = new();
        foreach (var err in errors)
        {
            switch (err.Code)
            {
                case nameof(IdentityErrorDescriber.DuplicateUserName):
                    Errors.Add(new(nameof(User.Email), localizer[MessageKeys.DuplicateEmailErrorMessage]));
                    break;
                case nameof(IdentityErrorDescriber.LoginAlreadyAssociated):
                    Errors.Add(new(nameof(User.Email), localizer[MessageKeys.LoginAlReadyAssociatedErrorMessage]));
                    break;
                default:
                    Errors.Add(new(err.Code, err.Description));
                    break;
            }
        }
        return Errors;
    }
}
