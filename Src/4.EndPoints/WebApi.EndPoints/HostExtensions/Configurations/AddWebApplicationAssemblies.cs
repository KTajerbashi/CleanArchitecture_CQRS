using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using WebApi.EndPoints.HostExtensions.Providers.FluentValidation;
using WebApi.EndPoints.HostExtensions.Providers.MediatR;

namespace WebApi.EndPoints.HostExtensions.Configurations;

public static class AddWebApplicationAssemblies
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                 IEnumerable<Assembly> assembliesForSearch)
        => services
                   .AddMediatRService(assembliesForSearch)
                   .AddFluentService(assembliesForSearch)
        ;

    
}
