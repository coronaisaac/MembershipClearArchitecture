using Membership.Abstractions.Options;
using Membership.Core.Controllers;
using Membership.Core.Interactors;
using Membership.Core.Presenters;
using Membership.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMembershipCoreServices(
            this IServiceCollection services,
            Action<JwtOptions> jwtOptionsSetter)
        {
            services.AddMembershipInteractors()
              .AddMembershipPresenters()
              .AddMembershipController()
              .AddMembershipInternalServices(jwtOptionsSetter);
            return services;
        }
    }
}
