using Microsoft.Extensions.Primitives;

namespace _2._Middleware_example.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/" && context.Request.Method == "POST")
            {
                StreamReader loginStreamReader = new StreamReader(context.Request.Body);
                string body = await loginStreamReader.ReadToEndAsync();
                string email = "", passwoord = "";
                string validEmail = "admin@gmail.com", validPasswoord = "admin123";
                Dictionary<string, StringValues> loginDetails = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
                if (loginDetails.ContainsKey("email"))
                {
                    email = Convert.ToString(loginDetails["email"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Please provide email!");
                }
                if (loginDetails.ContainsKey("password"))
                {
                    passwoord = Convert.ToString(loginDetails["password"][0]);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Please provide password!");
                }

                if (email == validEmail && passwoord == validPasswoord)
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("login successfull");
                }
                else
                {
                    await context.Response.WriteAsync("login failed!");
                }
            }
            await next(context);
            await context.Response.WriteAsync("This is from custom middleware End\n");
        }
    }

    public static class CustomMiddlewareExtension       //Extenstion means getting injected in object dynamically
    {
        public static IApplicationBuilder UseMyCustMiddleware( this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}
