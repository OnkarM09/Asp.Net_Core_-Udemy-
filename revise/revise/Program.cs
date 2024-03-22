using revise.Middlewares;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<CustomMiddlware>();
builder.Services.AddTransient<LoginMiddleware>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
