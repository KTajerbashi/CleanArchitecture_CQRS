using Microsoft.AspNetCore.Mvc.Filters;
using Serilog.Context;
using System.Text.Json;

namespace BaseSource.WebAPI.EndPoint.Providers.Serilog;

public class LogActionFilter : IActionFilter
{
    private readonly ILogger<LogActionFilter> _logger;

    public LogActionFilter(ILogger<LogActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];
        var parameters = JsonSerializer.Serialize(context.ActionArguments);
        // Read request body (buffered copy)
        request.EnableBuffering();
        var bodyReader = new StreamReader(request.Body);
        string requestBody = bodyReader.ReadToEnd();
        request.Body.Position = 0;

        using (LogContext.PushProperty("Controller", controller))
        using (LogContext.PushProperty("Action", action))
        using (LogContext.PushProperty("RequestBody", requestBody))
        {
            _logger.LogInformation("Handled request {Method} {Path}", request.Method, request.Path);
        }
        _logger.LogInformation("Executing Controller={Controller}, Action={Action}, Parameters={Parameters}",
            controller, action, parameters);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null && context.Result != null)
        {
            _logger.LogInformation("Executed Action Result: {Result}", context.Result.ToString());
        }
    }
}
