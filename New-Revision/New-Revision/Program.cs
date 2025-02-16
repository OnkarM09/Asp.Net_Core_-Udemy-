using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using New_Revision.Middlewares;
using New_Revision.Models;
using New_Revision.Serivices;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IHeroService, HeroService>();

builder.Services.AddDbContext<HeroesDbContext>((option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")))
);
var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();

app.Run();