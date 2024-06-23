using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.ApplicationServices.Queries;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Pattern;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureCQRS.Application.Library.BaseApplication.DIContainer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped<UtilitiesServices>();
            return services;

        }
      
    }

}
