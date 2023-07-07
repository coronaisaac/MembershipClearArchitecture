using Membership.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Membership.Shared.MessageLocalizer;
public static class DependencyContainer
{
    public static IServiceCollection AddMembershipMessageLocalizer(
        this IServiceCollection services)
    {
        services.TryAddSingleton<IMembershipMessageLocalizer,
            MembershipMessageLocalizer>();

        return services;
    }
}
