var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(
    context => context.Request.Query.ContainsKey("name"),
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from middleware branch");
            await next();
        });
    }
    );

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from main middleware chain");
});

app.Run();