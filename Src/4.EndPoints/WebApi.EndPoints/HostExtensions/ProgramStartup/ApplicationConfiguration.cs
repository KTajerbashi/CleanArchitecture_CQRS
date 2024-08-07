﻿using AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Extensions;
using CleanArchitectureCQRS.CommandsDb.Library.DIContainer;
using CleanArchitectureCQRS.QueriesDb.Library.DIContainer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Serilog;
using WebApi.EndPoints.HostExtensions.Configurations;
using WebApi.EndPoints.HostExtensions.Providers.Identity;
using WebApi.EndPoints.HostExtensions.Providers.Swagger;
using SOAPContainerServices.Extensions.DependencyInjection;
using CleanArchitectureCQRS.Application.Library.Aggregates.People.Repositories;
using CleanArchitectureCQRS.CommandsDb.Library.Aggregates.People;

namespace WebApi.EndPoints.HostExtensions.ProgramStartup;

public static class ApplicationConfiguration
{

    public static WebApplication AddServicesApplication(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var scopes = configuration.GetSection("Scopes").Value.Split(",");
        builder.Services.AddWebApiCore(scopes);

        builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

        builder.Services.AddIdentityServices(configuration);

        builder.Services.AddSwaggerServiceConfiguration(configuration, "Swagger");

        builder.Services.AddContextDatabaseCommandDependencies(configuration);

        builder.Services.AddContextDatabaseQueryDependencies(configuration);

        builder.Services.AddMvc();
        builder.Services.AddNotificationService();

        builder.Services.AddControllers();
        builder.Services.AddHangfireServices(configuration);

        return builder.Build();
    }
    public static WebApplication UsePipelineApplication(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSerilogRequestLogging();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseMiddleware<AuthenticationMiddleware>();

        app.UseApiExceptionHandler();

        app.UseSerilogRequestLogging();

        app.UseIdentity();

        app.UseSwaggerUI("Swagger");

        //app.UseStatusCodePages();

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        app.UseHangfireProvider();

        app.MapControllers();

        app.UseHttpsRedirection();

        return app;
    }

}
