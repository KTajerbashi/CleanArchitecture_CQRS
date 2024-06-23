using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Events;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Transactions;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Databases;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using CleanArchitectureCQRS.Application.Library.Databases;
using CleanArchitectureCQRS.CommandsDb.Library.Database;
using CleanArchitectureCQRS.ContextDatabase.Library.Databases.Contexts;
using CleanArchitectureCQRS.QueriesDb.Library.Database;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace WebApi.EndPoints.DIContainers;

public static class DependencyInjection
{
    /// <summary>
    /// سرویس های پایگاه داده را تزریق میکند
    /// </summary>
    /// <param name="services"></param>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationDatabase(this IServiceCollection services, WebApplicationBuilder builder)
    {
        //// Sample Database Config
        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
        });
        builder.Services.AddScoped<IApplicationContext, ApplicationContext>();


        //// Command Database Config
        services.AddDbContext<CommandApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionCommandDatabase"),
            b => b.MigrationsAssembly(typeof(CommandApplicationContext).Assembly.FullName));
        });
        builder.Services.AddScoped<ICommandApplicationContext, CommandApplicationContext>();


        //// Query Database Config
        services.AddDbContext<QueryApplicationContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionQueryDatabase"),
            b => b.MigrationsAssembly(typeof(QueryApplicationContext).Assembly.FullName));
        });
        builder.Services.AddScoped<IQueryApplicationContext, QueryApplicationContext>();

        return services;

    }
    
    /// <summary>
    /// سرویس های اپلیکشن را تزریق میکند
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                  IEnumerable<Assembly> assembliesForSearch)
         => services.AddCommandHandlers(assembliesForSearch)
                    //.AddCommandDispatcherDecorators()
                    .AddQueryHandlers(assembliesForSearch)
                    //.AddQueryDispatcherDecorators()
                    .AddEventHandlers(assembliesForSearch)
                    //.AddEventDispatcherDecorators()
                    .AddFluentValidators(assembliesForSearch);


    
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblyNamesForSearch"></param>
    /// <returns></returns>
    public static IServiceCollection AddDependencies(this IServiceCollection services,
        params string[] assemblyNamesForSearch)
    {

        var assemblies = GetAssemblies(assemblyNamesForSearch);
        services
            .AddApplicationServices(assemblies)
            .AddDataAccess(assemblies)
            .AddUntilityServices()
            .AddCustomeDepenecies(assemblies);
        return services;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assemblies"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomeDepenecies(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        return services.AddWithTransientLifetime(assemblies, typeof(ITransientLifetime))
            .AddWithScopedLifetime(assemblies, typeof(IScopeLifetime))
            .AddWithSingletonLifetime(assemblies, typeof(ISingletoneLifetime));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <param name="assignableTo"></param>
    /// <returns></returns>
    public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
       IEnumerable<Assembly> assembliesForSearch,
       params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <param name="assignableTo"></param>
    /// <returns></returns>
    public static IServiceCollection AddWithSingletonLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
        return services;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddUntilityServices(
    this IServiceCollection services)
    {
        services.AddTransient<UtilitiesServices>();
        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) => 
            services
                    .AddRepositories(assembliesForSearch)
                    .AddUnitOfWorks(assembliesForSearch);


    /// <summary>
    /// تزریق کردن ریپازیتوری های کاماند
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<,>), typeof(IQueryRepository));


    /// <summary>
    /// تزریق کردن یونیت آف ورک
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    public static IServiceCollection AddUnitOfWorks(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(IUnitOfWork));


    /// <summary>
    /// تزریق هندلر های کاماند
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    private static IServiceCollection AddCommandHandlers(this IServiceCollection services, 
        IEnumerable<Assembly> assembliesForSearch)
        => services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

    /// <summary>
    /// تزریق هندلر های کویری
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    private static IServiceCollection AddQueryHandlers(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddWithTransientLifetime(assembliesForSearch, typeof(IQueryHandler<,>));


    /// <summary>
    /// تزریق هندلر های ایوینت
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    private static IServiceCollection AddEventHandlers(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddWithTransientLifetime(assembliesForSearch, typeof(IDomainEventHandler<>));

    /// <summary>
    /// تزریق کردن سرویس های اعتبار سنجی
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <returns></returns>
    private static IServiceCollection AddFluentValidators(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
        => services.AddValidatorsFromAssemblies(assembliesForSearch);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembliesForSearch"></param>
    /// <param name="assignableTo"></param>
    /// <returns></returns>
    public static IServiceCollection AddWithTransientLifetime(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="assmblyName"></param>
    /// <returns></returns>
    private static List<Assembly> GetAssemblies(string[] assmblyName)
    {

        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assmblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="compilationLibrary"></param>
    /// <param name="assmblyName"></param>
    /// <returns></returns>
   
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assmblyName)
    {
        return assmblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assmblyName.Any(c => d.Name.Contains(c)));
    }

}

