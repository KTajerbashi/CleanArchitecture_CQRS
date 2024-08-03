using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace WebApi.EndPoints.HostExtensions.Providers.HttpAccessor;

public static class HttpContextExtensions
{
    public static UtilitiesServices ApplicationContext(this HttpContext httpContext) => (UtilitiesServices)httpContext.RequestServices.GetService(typeof(UtilitiesServices));
}