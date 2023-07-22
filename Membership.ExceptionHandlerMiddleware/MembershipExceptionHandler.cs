namespace Membership.ExceptionHandlerMiddleware
{
    public class MembershipExceptionHandler
    {
        public static async Task<bool> WriteResponse(HttpContext httpContext,IMembershipMessageLocalizer localizer)
        {
            IExceptionHandlerFeature exceptionHandler = httpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = exceptionHandler?.Error;
            bool handled = true;
            if (exception != null)
            {
                switch (exception)
                {
                    case RegisterUserException ex:
                        await Write400BadRequestAsync(
                            httpContext, 
                            localizer[MessageKeys.RegisterUserExceptionMessage], 
                            nameof(RegisterUserException),
                            ex.Errors);
                        break;
                    case LoginUserException:
                        await Write400BadRequestAsync(
                            httpContext,
                            localizer[MessageKeys.LoginUserExceptionMessage],
                            nameof(LoginUserException));
                        break;
                    case RefreshTokenCompromiseException:
                        await Write400BadRequestAsync(
                            httpContext,
                            localizer[MessageKeys.RefreshTokenCompromisedExceptionMessage],
                            nameof(RefreshTokenCompromiseException));
                        break;
                    case RefreshTokenExpiredException:
                        await Write400BadRequestAsync(
                            httpContext,
                            localizer[MessageKeys.RefreshTokenExpiredExceptionMessage],
                            nameof(RefreshTokenExpiredException));
                        break;
                    case RefreshTokenNotFoundException:
                        await Write400BadRequestAsync(
                            httpContext,
                            localizer[MessageKeys.RefreshTokenNotFoundExceptionMessage],
                            nameof(RefreshTokenNotFoundException));
                        break;

                    default:
                        handled = false;
                        break;
                }
            }
            return handled;
        }
        static async Task Write400BadRequestAsync(HttpContext context, string title, string instance, object extencions =  null)
        {
            ProblemDetails problem = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = title,
                Instance = $"problemDetails/{instance}"
            };
            if(extencions!= null) 
                problem.Extensions.Add("errors", extencions);

            await WriteProblemDetailsAsync(context,problem);
        }
        static async Task WriteProblemDetailsAsync(HttpContext context, ProblemDetails details)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = details.Status.Value;
            var stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(stream, details);
        }
    }
}
