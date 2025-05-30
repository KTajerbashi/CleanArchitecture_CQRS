namespace BaseSource.WebAPI.EndPoint.Middleware.ValidationHandler;

public static class ValidationExceptionExtensions
{
    public static void UseValidationExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ValidationExceptionMiddleware>();
    }
}
