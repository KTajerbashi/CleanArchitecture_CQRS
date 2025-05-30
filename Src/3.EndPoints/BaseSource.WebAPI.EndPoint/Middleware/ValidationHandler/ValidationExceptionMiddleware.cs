using Microsoft.AspNetCore.Http;
using System.Text;

namespace BaseSource.WebAPI.EndPoint.Middleware.ValidationHandler;
public class ValidationExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ValidationExceptionMiddleware> _logger;

    public ValidationExceptionMiddleware(RequestDelegate next, ILogger<ValidationExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            StringBuilder messageFormat = new();
            ex.Errors.ToList().ForEach(e => messageFormat.AppendLine(e.ErrorMessage));
            var response = new
            {
                Message = messageFormat.ToString(),
                StatusCode = context.Response.StatusCode,
                Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
