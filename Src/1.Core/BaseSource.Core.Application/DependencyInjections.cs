using BaseSource.Core.Application.Providers;
using FluentValidation;
namespace BaseSource.Core.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(assemblies);
        });


        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<ProviderFactory>();
        return services;
    }

}
