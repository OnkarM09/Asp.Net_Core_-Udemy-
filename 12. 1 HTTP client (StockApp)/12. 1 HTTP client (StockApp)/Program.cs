using _12._1_HTTP_client__StockApp_.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Adding http client service
builder.Services.AddHttpClient();

//Adding MyService 
builder.Services.AddScoped<FinnhubService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
