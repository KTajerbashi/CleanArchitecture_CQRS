using BaseSource.WebAPI.EndPoint.Middleware.ValidationHandler;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace BaseSource.WebAPI.EndPoint.Middleware.ExceptionHandler;

public class ApiErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
public static class ApiExceptionMiddlewareExtensions
{
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        ILoggerFactory loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;

                    var statusCode = exception switch
                    {
                        FluentValidation.ValidationException => HttpStatusCode.BadRequest,
                        UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                        KeyNotFoundException => HttpStatusCode.NotFound,
                        _ => HttpStatusCode.InternalServerError
                    };

                    context.Response.StatusCode = (int)statusCode;

                    var errorResponse = new ApiErrorResponse
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = exception.Message,
                        Errors = exception is FluentValidation.ValidationException validationException
                            ? validationException.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}")
                            : null!
                    };

                    logger.LogError(exception, "Unhandled exception occurred");

                    var json = JsonSerializer.Serialize(errorResponse);
                    await context.Response.WriteAsync(json);
                }
            });
        });
    }
}
