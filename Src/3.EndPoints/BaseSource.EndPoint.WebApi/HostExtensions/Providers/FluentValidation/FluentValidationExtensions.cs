using FluentValidation;
using System.Reflection;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Providers.FluentValidation;

public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentService(this IServiceCollection services, IEnumerable<Assembly> assembliesForSearch)
      => services.AddValidatorsFromAssemblies(assembliesForSearch);
}
