using Membership.Abstractions.Interfaces.Logout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Controllers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipController(this IServiceCollection services)
        {
            services.AddScoped<IRegisterController, RegisterController>();
            services.AddScoped<ILoginController, LoginController>();
            services.AddScoped<ILogoutController, LogoutController>();
            services.AddScoped<IRefreshTokenController, RefreshTokenController>();
            return services;
        }
    }
}
