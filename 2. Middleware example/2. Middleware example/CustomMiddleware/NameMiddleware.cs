using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _2._Middleware_example.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NameMiddleware
    {
        private readonly RequestDelegate _next;

        public NameMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("fullname"))
            {
                string name = httpContext.Request.Query["fullname"];
                await httpContext.Response.WriteAsync($"Your name is {name}\n");
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NameMiddlewareExtensions
    {
        public static IApplicationBuilder UseNameMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NameMiddleware>();
        }
    }
}
