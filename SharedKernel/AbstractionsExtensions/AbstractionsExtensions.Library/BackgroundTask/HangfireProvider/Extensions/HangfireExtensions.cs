using AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Filters;
using AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Repositories;
using AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Services;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbstractionsExtensions.Library.BackgroundTask.HangfireProvider.Extensions;

public static class HangfireExtensions
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHangfire(config =>
          config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton<IJwtFactory, JwtFactory>();
        //services
        //    .AddHangfire(option => option
        //    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //    .UseSimpleAssemblyNameTypeSerializer()
        //    .UseRecommendedSerializerSettings()
        //    .UseSqlServerStorage(configuration.GetConnectionString(configuration.GetConnectionString("DefaultConnection")), new SqlServerStorageOptions
        //    {
        //        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //        QueuePollInterval = TimeSpan.Zero,
        //        UseRecommendedIsolationLevel = true,
        //        UsePageLocksOnDequeue = true,
        //        DisableGlobalLocks = true
        //    }));

        // Add the processing server as IHostedService
        services.AddHangfireServer();

        return services;
    }

    public static void UseHangfireProvider(this WebApplication app)
    {
        app.UseHangfireServer();
        app.UseHangfireDashboard("/dashboard/free");
        app.UseHangfireDashboard("/dashboard/application", new DashboardOptions
        {
            DashboardTitle = "CleanArchitectureCQRS",

        });


        var hangFireDashboardOptions = new DashboardOptions
        {
            DashboardTitle = "CleanArchitectureCQRS",
            // To remove back link
            AppPath = null,
            Authorization = new[]{new HangfireAuthenticationIdentityFilter() }
            //Authorization = new[]{new HangfireAuthenticationJWTFilter() }
        };
        app.UseHangfireDashboard("/hangfire", hangFireDashboardOptions);
    }
}
