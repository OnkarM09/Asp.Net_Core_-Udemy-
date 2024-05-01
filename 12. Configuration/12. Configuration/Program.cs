using _12._Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Supplying options WeatherApi from appsetting (Configuration) as a service using DI.
builder.Services.Configure<Weather>
(builder.Configuration.GetSection("WeatherApi"));


//Load myownconfig.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);  //We are saying this optional
});
var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async (context) =>
    {
        //await context.Response.WriteAsync(app.Configuration["MyVal"]);
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyVal"));
        //await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10));  //Default value
    });

});
app.MapControllers();

app.Run();
