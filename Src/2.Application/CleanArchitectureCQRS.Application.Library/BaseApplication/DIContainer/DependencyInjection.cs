using CleanArchitectureCQRS.Application.Library.BaseApplication.BaseCommandQuery.Pattern;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.DIContainer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;

        }
    }
}
