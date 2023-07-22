namespace Membership.UserManagerService.AspNetIdentity;
public static class DependencyContainer
{
    public static IServiceCollection AddUserManagerAspNetIdentityService(
        this IServiceCollection services,Action<AspNetIdentityOptions> action)
    {
        services.AddOptions<AspNetIdentityOptions>()
            .Configure(action);

        services.AddDbContext<UserManagerServiceContext>();

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<UserManagerServiceContext>();

        services.AddSingleton<UserManagerErrorHandler>();

        services.AddScoped<IUserManagerService, Services.UserManagerService>();
        return services;
    }
}
