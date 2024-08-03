using Azure;
using FluentValidation;
using System.Diagnostics;
using System.Net;

namespace WebApi.EndPoints.Middlewares.ApiExceptionHandler
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionMiddleware> _logger;
        private readonly ApiExceptionOptions _options;

        public ApiExceptionMiddleware(
            ApiExceptionOptions options, 
            RequestDelegate next,
            ILogger<ApiExceptionMiddleware> logger
            )
        {
            _next = next;
            _logger = logger;
            _options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.TraceIdentifier = Activity.Current?.Id ?? context?.TraceIdentifier;
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new ApiError
            {
                Id = Guid.NewGuid().ToString(),
                Status = (short)HttpStatusCode.InternalServerError,
                Title = $"{exception.InnerException}",
                TraceId = context.TraceIdentifier,
            };

            _options.AddResponseDetails?.Invoke(context, exception, error);

            var innerExMessage = GetInnermostExceptionMessage(exception);

            var level = _options.DetermineLogLevel?.Invoke(exception) ?? LogLevel.Error;
            _logger.Log(level, exception, "BADNESS!!! " + innerExMessage + " -- {ErrorId}.", error.Id);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = exception switch
            {
                ValidationException => exception.Message,
                UnauthorizedAccessException => exception.Message,
                KeyNotFoundException => exception.Message,
                _ => "Internal Server Error from the custom middleware."
            };
            var errorJson = System.Text.Json.JsonSerializer.Serialize(new
            {
                Error = error,
                Message = message,
                StatusCode = context.Response.StatusCode,

            });
            return context.Response.WriteAsync(new ErrorDetails()
            {
                Errors = errorJson,
            }.ToString());

        }
        private string GetInnermostExceptionMessage(Exception exception)
        {
            if (exception.InnerException != null)
                return GetInnermostExceptionMessage(exception.InnerException);

            return exception.Message;
        }
    }
}
