using Microsoft.EntityFrameworkCore;
using New_Revision.Models;
using New_Revision.Serivices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IHeroService, HeroService>();
builder.Services.AddDbContext<HeroesDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HeroesDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
