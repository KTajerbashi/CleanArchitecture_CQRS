using Microsoft.OpenApi.Models;

namespace BaseSource.WebAPI.EndPoint.Providers.Swagger;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerProvider(this IServiceCollection services)
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });
        return services;
    }

    public static void UseSwaggerProvider(this WebApplication app)
    {
        app.UseSwagger();
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
        // specifying the Swagger JSON endpoint.
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });
    }
}
