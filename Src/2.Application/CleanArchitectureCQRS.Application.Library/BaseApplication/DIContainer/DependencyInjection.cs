using CleanArchitectureCQRS.Application.Library.BaseApplication.Behaviors;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.DIContainer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                //cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            });
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped<UtilitiesServices>();
            return services;

        }

    }

}
