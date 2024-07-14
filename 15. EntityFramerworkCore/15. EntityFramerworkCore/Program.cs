using _15._EntityFramerworkCore;
using _15._EntityFramerworkCore.Filters.ActionFilters;
using _15._EntityFramerworkCore.Filters.ResultFilters;
using _15._EntityFramerworkCore.Middleware;
using _15._EntityFramerworkCore.Models;
using _15._EntityFramerworkCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureServices(builder.Configuration);

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseExceptionHandlingMiddleware();
}

Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Logger.LogDebug("Debugging!");
app.Logger.LogInformation("Debugging!");
app.Logger.LogWarning("Debugging!");
app.Logger.LogError("Debugging!");
app.Logger.LogCritical("Debugging!");

app.Run();
