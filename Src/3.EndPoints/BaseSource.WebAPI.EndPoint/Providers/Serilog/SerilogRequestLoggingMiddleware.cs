using Serilog.Context;
using System.Text;

namespace BaseSource.WebAPI.EndPoint.Providers.Serilog;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;

        // Read request body (buffered copy)
        request.EnableBuffering();
        var bodyReader = new StreamReader(request.Body);
        string requestBody = await bodyReader.ReadToEndAsync();
        request.Body.Position = 0;

        // Get route data
        var controller = context.GetRouteValue("controller")?.ToString();
        var action = context.GetRouteValue("action")?.ToString();

        using (LogContext.PushProperty("Controller", controller))
        using (LogContext.PushProperty("Action", action))
        using (LogContext.PushProperty("RequestBody", requestBody))
        {
            _logger.LogInformation("Handled request {Method} {Path}", request.Method, request.Path);
        }

        await _next(context);
    }
}

