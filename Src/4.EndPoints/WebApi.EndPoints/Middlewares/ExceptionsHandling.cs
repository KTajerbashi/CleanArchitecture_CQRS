using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.EndPoints.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionsHandling
    {
        private readonly RequestDelegate _next;

        public ExceptionsHandling(RequestDelegate next)
        {
            Console.WriteLine("INFO UP : ExceptionsHandling");
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("INFO UP : Invoke");
            try
            {
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"INFO Down {ex.Message}");
                throw;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionsHandlingExtensions
    {
        public static IApplicationBuilder UseExceptionsHandling(this IApplicationBuilder builder)
        {
            Console.WriteLine("INFO UP : UseExceptionsHandling");
            return builder.UseMiddleware<ExceptionsHandling>();
            Console.WriteLine("INFO Down : UseExceptionsHandling");
        }
    }
}
