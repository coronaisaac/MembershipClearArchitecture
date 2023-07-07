using Membership.Abstractions.Interfaces.Logout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Interactors
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipInteractors(this IServiceCollection services)
        {
            services.AddScoped<IRegisterInputPort, RegisterInteractor>();
            services.AddScoped<ILoginInputPort, LoginInteractor>();
            services.AddScoped<ILogoutInputPort, LogoutInteractor>();
            services.AddScoped<IRefreshTokenInputPort, RefreshTokenInteractor>();
            return services;
        }
    }
}
