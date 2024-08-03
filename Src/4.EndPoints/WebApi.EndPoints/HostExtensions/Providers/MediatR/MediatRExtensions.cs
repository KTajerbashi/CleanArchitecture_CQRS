using CleanArchitectureCQRS.Application.Library.BaseApplication.Behaviors;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using MediatR;
using System.Reflection;

namespace WebApi.EndPoints.HostExtensions.Providers.MediatR;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatRService(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
    {
        services.AddMediatR(cfg =>
        {
            //cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            foreach (var assembly in assembliesForSearch)
            {
                cfg.RegisterServicesFromAssembly(assembly);
            }
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        });
        services.AddScoped<UtilitiesServices>();
        return services;
    }
}
