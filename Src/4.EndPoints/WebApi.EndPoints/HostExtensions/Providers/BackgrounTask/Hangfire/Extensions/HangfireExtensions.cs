using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.EndPoints.HostExtensions.Providers.BackgrounTask.Hangfire.Filter;

namespace WebApi.EndPoints.HostExtensions.Providers.BackgrounTask.Hangfire.Extensions;

public static class HangfireExtensions
{
    public static IServiceCollection AddHangfireServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(option => option
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                UsePageLocksOnDequeue = true,
                DisableGlobalLocks = true
            }));

        // Add the processing server as IHostedService
        services.AddHangfireServer();
        return services;
    }

    public static void UseHangfireProvider(this WebApplication app)
    {
        app.UseHangfireDashboard("/dashboard.user");
        app.UseHangfireDashboard("/dashboard.admin", new DashboardOptions
        {
            Authorization = new[] { new HangfireAuthenticationFilter() }
        });
        app.UseHangfireDashboard("/dashboard.admin.jwt", new DashboardOptions
        {
            Authorization = new[] { new HangfireAuthenticationFilter() }
        });

        app.UseHangfireServer();
    }
}
