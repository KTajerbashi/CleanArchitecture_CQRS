using Autofac.Core;
using BaseSource.Core.Application.Common.RepositoryPatttern;
using BaseSource.Core.Infrastrcuture.SQL.Command.Common.DataContext.Interceptors.ShadowProperties;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace BaseSource.Core.Infrastrcuture.SQL.Command;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureCommandServices(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddScoped<ISaveChangesInterceptor, AddAuditDataInterceptor>();

        services.AddDbContext<CommandDataContext>(option =>
        {
            option
            .UseSqlServer(configuration.GetConnectionString("CommandConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(CommandDataContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                })
            .AddInterceptors(new AddAuditDataInterceptor())
            ;
        });

        //services.AddDbContext<CommandDataContext>((sp, options) =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("CommandConnection"),
        //        sqlServerOptionsAction: sqlOptions =>
        //        {
        //            sqlOptions.MigrationsAssembly(typeof(CommandDataContext).Assembly.FullName);
        //            sqlOptions.EnableRetryOnFailure();
        //        });
        //    options.AddInterceptors(sp.GetRequiredService<AddAuditDataInterceptor>());
        //});

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
