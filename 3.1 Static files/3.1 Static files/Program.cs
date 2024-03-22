using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});

var app = builder.Build();

app.UseStaticFiles();   //this is for myroot
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath,"mywebroot")  //We have also registered mywebroot for static files.
        )
});

app.MapGet("/", () => "Hello World!");

app.Run();
