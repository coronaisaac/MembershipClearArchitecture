using Membership.Abstractions.Interfaces.Logout;
using Membership.Abstractions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipInternalServices(
            this IServiceCollection services,
            Action<JwtOptions> jwtOptionsSetter)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserService, UserService>();
            services.AddOptions<JwtOptions>()
                .Configure(jwtOptionsSetter);
            services.AddSingleton<IAccessTokenService, AccessTokenServices>();
            return services;
        }
    }
}
