using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace New_Revision.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if(context.Request.Path == "/" && context.Request.Method == "POST")
            {
                StreamReader loginStramReader = new StreamReader(context.Request.Body);
                string body = await loginStramReader.ReadToEndAsync();
                string email = "", password = "";
                string validEmail = "admin@gmail.com", validPassword = "admin1024";
                Dictionary<string, StringValues> loginDetails = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

                if (loginDetails.ContainsKey("email"))
                {
                    email = Convert.ToString(loginDetails["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid Email");
                }
                if (loginDetails.ContainsKey("password"))
                {
                    password = Convert.ToString(loginDetails["password"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid Password");
                }
                if(email == validEmail && password == validPassword)
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Login Successfull!");
                }

            }
            await context.Response.WriteAsync("From custom middleware");
            await next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
