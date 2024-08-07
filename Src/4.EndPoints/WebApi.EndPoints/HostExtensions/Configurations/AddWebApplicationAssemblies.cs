using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Commands;
using CleanArchitectureCQRS.Application.Library.BaseApplication.Contracts.Data.Queries;
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
                   .AddRepositories(assembliesForSearch)
        ;

    public static IServiceCollection AddRepositories(
    this IServiceCollection services,
    IEnumerable<Assembly> assembliesForSearch) =>
    services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandRepository<,>), typeof(IQueryRepository));

}
