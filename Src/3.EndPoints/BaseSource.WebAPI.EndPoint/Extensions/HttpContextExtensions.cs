using BaseSource.Core.Application.Providers;

namespace BaseSource.WebAPI.EndPoint.Extensions;
public static class HttpContextExtensions
{
    public static ProviderFactory ApplicationContext(this HttpContext httpContext) =>
        (ProviderFactory)httpContext.RequestServices.GetService(typeof(ProviderFactory))!;

}