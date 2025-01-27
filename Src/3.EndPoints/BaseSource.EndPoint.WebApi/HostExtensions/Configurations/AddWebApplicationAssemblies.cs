using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Commands;
using BaseSource.Core.Application.Library.BaseApplication.Contracts.Data.Queries;
using BaseSource.EndPoint.WebApi.HostExtensions.Providers.FluentValidation;
using BaseSource.EndPoint.WebApi.HostExtensions.Providers.MediatR;
using System.Reflection;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Configurations;

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
