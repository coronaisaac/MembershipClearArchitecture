using Membership.Abstractions.Interfaces.Logout;
using Membership.Shared.Dtos;
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
            app.MapPost("/user/register", async (IRegisterController controller,UserDto UserDto ) =>
            {
                await controller.RegisterAsync(UserDto);
                return Results.Ok();
            });

            app.MapPost("/user/login", async (ILoginController controller, UserCredentialsDto user, HttpContext context) =>
            {
                context.Response.Headers.Add("Cache-Control","no-store");
                return Results.Ok(await controller.LoginAsync(user));
            });

            app.MapPost("/user/logout", async (ILogoutController controller, UserTokenDto userTokenDto) => 
            {
                await controller.LogoutAsync(userTokenDto);
                return Results.Ok();
            });

            app.MapPost("/user/refreshToken", async (IRefreshTokenController controller, UserTokenDto userTokens, HttpContext context) =>
            {
                context.Response.Headers.Add("Cache-Control", "no-store");
                return Results.Ok(await controller.RefreshTokenAsync(userTokens));
            });
            return app;
        }
    }
}
