using Microsoft.AspNetCore.Diagnostics;

namespace Jtbuk.VerticalArchitecture.Common.Exceptions;

public static class GlobalExceptionHandler
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var error = new CustomError("Something went wrong");

                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                if(exceptionHandlerPathFeature?.Error is NotFoundException notFoundException)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    error = notFoundException.ErrorObject;
                }

                var responseJson = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(responseJson);
            });
        });
    }
}
