using _15._EntityFramerworkCore.Filters.ActionFilters;
using _15._EntityFramerworkCore.Filters.ResultFilters;
using _15._EntityFramerworkCore.Models;
using _15._EntityFramerworkCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews( options =>
{
    //options.Filters.Add<ResponseHeaderActionFilter>();   //Adding filter globally  for entire project  
    //How to add arguments in this case?

    //We have to use different way
  //  var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();
    options.Filters.Add(new ResponseHeaderActionFilter("my-global-key", "my-global-value", 2));
});
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<PersonsListResultFilter>();
builder.Services.AddDbContext<PersonsDbContext>( options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));   //Connecting mssql server
});

//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
var app = builder.Build();

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
