using AbstractionsExtensions.Library.UsersManagement.Services.Extensions.DependencyInjection;
using CleanArchitectureCQRS.Application.Library.BaseApplication.DIContainer;
using CleanArchitectureCQRS.ContextDatabase.Library.DIContainer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using WebApi.EndPoints.DIContainers;
using WebApi.EndPoints.HostExtensions.Identity;
using WebApi.EndPoints.HostExtensions.Swagger;
using WebApi.EndPoints.Middlewares;

namespace WebApi.EndPoints.HostExtensions.ServiceExtensions;

public static class ServiceInjectionExtensions
{
    public static WebApplication ApplicationServices(this WebApplicationBuilder builder)
    {
        var configurationBuilder = builder.GetConfiguration();
        var configuration = builder.Configuration;

        builder.Services.AddDependencies("CleanArchitectureCQRS");
        builder.Services.AddWebApiCore("CleanArchitectureCQRS");
        builder.Services.AddWebUserInfoService(configuration, "CleanArchitectureCQRS", true);
        builder.Services.AddApplicationDependencies();
        builder.Services.AddContextDatabaseDependencies(configuration);
        builder.Services.ConfigureServices(configuration);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddIdentityService();

        builder.Services.SwaggerService(configuration, "Swagger");
        return builder.Build();
    }

    public static WebApplication ApplicationPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI("Swagger");
        }
        app.UseExceptionsHandling();
        app.UseHttpsRedirection();

        app.UseIdentity();

        app.MapControllers();

        app.Run();
        return app;
    }

    private static IConfigurationBuilder GetConfiguration(this WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables();
        return configuration;
    }
}
