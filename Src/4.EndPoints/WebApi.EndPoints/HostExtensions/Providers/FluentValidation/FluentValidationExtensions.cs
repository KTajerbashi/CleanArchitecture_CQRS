using FluentValidation;
using System.Reflection;

namespace WebApi.EndPoints.HostExtensions.Providers.FluentValidation;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentService(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
      => services.AddValidatorsFromAssemblies(assembliesForSearch);
}
