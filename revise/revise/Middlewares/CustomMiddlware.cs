namespace revise.Middlewares
{
    public class CustomMiddlware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
         
            await context.Response.WriteAsync("Hello from custom middleware\n");
            await next(context);
            await context.Response.WriteAsync("Bye from custom middleware\n");
        }
    }
}
