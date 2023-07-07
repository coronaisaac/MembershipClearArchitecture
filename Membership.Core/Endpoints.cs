using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Core
{
    public static  class Endpoints
    {
        public static WebApplication UseMembershipEndpoints(this WebApplication app)
        {
            return app;
        }
    }
}
