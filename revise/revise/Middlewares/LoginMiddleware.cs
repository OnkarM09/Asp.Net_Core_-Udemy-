using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace revise.Middlewares
{
    public class LoginMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            StreamReader loginreader = new StreamReader(context.Request.Body);
            string body = await loginreader.ReadToEndAsync();
            string email = null, password = null;

            Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

            if (queryDict.ContainsKey("email"))
            {
                email = queryDict["email"][0];
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid request for input email!");
            }
            if (queryDict.ContainsKey("password"))
            {
                password = queryDict["password"][0];
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid request for input password!");
            }

            string validateUserEmail = "admin@gmail.com", validatePassword = "admin";

            if (email == validateUserEmail && password == validatePassword)
            {
                await context.Response.WriteAsync("Login successful!");
            }
            else
            {
                await context.Response.WriteAsync("Login failed.");
            }

            await context.Response.WriteAsync(body);
            await next(context);
        }
    }
}
