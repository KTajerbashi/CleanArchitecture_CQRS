using BaseSource.EndPoint.WebApi.HostExtensions.Configurations;
using BaseSource.EndPoint.WebApi.Middlewares.ApiExceptionHandler;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Configurations;
public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddWebApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services.AddControllers();
        services.AddDependencies(assemblyNamesForLoad);
        return services;
    }
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseApiExceptionHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == typeof(Microsoft.Data.SqlClient.SqlException).Name)
                {
                    error.Detail = "Exception was a database exception!";
                }
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                {
                    return LogLevel.Critical;
                }
                return LogLevel.Error;
            };
        });
    }

}
