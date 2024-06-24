using CleanArchitectureCQRS.Application.Library.BaseApplication.Utilities;

namespace WebApi.EndPoints.DIContainers
{
    public static class HttpContextExtensions
    {
        public static UtilitiesServices ApplicationContext(this HttpContext httpContext) =>
            (UtilitiesServices)httpContext.RequestServices.GetService(typeof(UtilitiesServices));
    }
}
