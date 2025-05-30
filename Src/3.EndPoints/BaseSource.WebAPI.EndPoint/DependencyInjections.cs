using BaseSource.WebAPI.EndPoint.Providers.Swagger;

namespace BaseSource.WebAPI.EndPoint;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebAPIService(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddControllers();
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        //  Swagger
        builder.Services.AddSwaggerProvider();

        return builder;
    }

    public static WebApplication UseWebAPIService(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            //  Swagger
            app.UseSwaggerProvider();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
