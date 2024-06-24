using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace WebApi.EndPoints.DIContainers;

public static class AddServicesExtensions
{
    public static IServiceCollection AddUntilityServices(
        this IServiceCollection services)
    {
        services.AddTransient<UtilitiesServices>();
        return services;
    }
}