using _4._Controllers.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();   //Adds all the controllers in the .net project (class which are prefixed with controller)
var app = builder.Build();

/*app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});*/

app.MapControllers();  //Enables routing for contollers (attribute routing)

app.UseStaticFiles();
app.Run();
