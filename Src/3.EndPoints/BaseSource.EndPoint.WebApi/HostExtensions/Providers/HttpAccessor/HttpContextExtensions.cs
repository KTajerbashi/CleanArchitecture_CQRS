using BaseSource.Core.Application.Library.Providers;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Providers.HttpAccessor;

public static class HttpContextExtensions
{
    public static ProviderUtilities ApplicationContext(this HttpContext httpContext) 
        => (ProviderUtilities)httpContext.RequestServices.GetService(typeof(ProviderUtilities));
}