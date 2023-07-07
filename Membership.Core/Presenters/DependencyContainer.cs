using Membership.Abstractions.Interfaces.Logout;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipPresenters(this IServiceCollection services)
        {
            services.AddScoped<ILoginOutputPort,LoginPresenter> ();
            services.AddScoped<IRefreshTokenOutput, RefreshTokenPresenter>();
            return services;
        }
    }
}
