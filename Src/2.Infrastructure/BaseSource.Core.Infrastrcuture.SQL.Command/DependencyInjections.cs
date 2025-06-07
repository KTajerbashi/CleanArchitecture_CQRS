using BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext.Interceptors.ShadowProperties;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BaseSource.Core.Infrastrcuture.SQL.Command;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureCommandServices(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddScoped<ISaveChangesInterceptor, AddAuditDataInterceptor>();

        services.AddDbContext<CommandDataContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("CommandConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(CommandDataContext).Assembly.FullName);
                    // Configure retry options with sensible defaults
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }
                )
            .AddInterceptors(new AddAuditDataInterceptor());
        });

        services.AddScoped<InitialCommandDataContext>();

        services.AddRepositories(assemblies);

        return services;
    }

    /// <summary>
    /// Scrutor
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly[] assemblies)
    {
        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes =>
                classes.Where(type => type.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(ICommandRepository<,>))))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        // Also register the open generic fallback if needed
        //services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandRepository<,>));

        return services;
    }


}
