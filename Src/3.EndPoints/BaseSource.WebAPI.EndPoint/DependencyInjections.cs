﻿using BaseSource.Core.Application.Utilities;
using BaseSource.WebAPI.EndPoint.Providers.Swagger;
using BaseSource.Core.Application;
using BaseSource.WebAPI.EndPoint.Middleware.ValidationHandler;
using BaseSource.WebAPI.EndPoint.Middleware.ExceptionHandler;
using BaseSource.Utilities;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using BaseSource.Utilities.Autofac;
using BaseSource.Core.Infrastrcuture.SQL.Query;
using BaseSource.Core.Infrastrcuture.SQL.Command;
using BaseSource.Core.Infrastrcuture.SQL.Command.DataContext;
using BaseSource.WebAPI.EndPoint.Providers.Identity;
using BaseSource.WebAPI.EndPoint.Providers.Serilog;

namespace BaseSource.WebAPI.EndPoint;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddWebAPIService(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var assemblies = ("BaseSource").GetAssemblies().ToArray();

        // Configure Autofac
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.AddAutofacLifetimeServices(assemblies);
            });

        // Add Http Context Accessor.
        builder.Services.AddHttpContextAccessor();

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        //  Swagger
        builder.Services.AddSwaggerProvider(configuration);

        //  BaseSource Utilities
        builder.Services.AddBaseSourceUtilities(configuration, assemblies);

        builder.Services.AddIdentity(configuration, "Identity");

        builder.Services.AddApplicationService(assemblies);

        builder.Services.AddInfrastructureCommandServices(configuration,assemblies);
        
        builder.Services.AddInfrastructureQueryServices(configuration, assemblies);

        return builder;
    }

    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var initialiser = scope.ServiceProvider.GetRequiredService<InitialCommandDataContext>();
        await initialiser.RunAsync();
    }

    public static WebApplication UseWebAPIService(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();

            //  Swagger
            app.UseSwaggerProvider();
        }
        
        app.UseMiddleware<RequestLoggingMiddleware>();
        
        app.UseValidationExceptionHandler();
        
        app.UseApiExceptionHandler();
        
        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }
}
