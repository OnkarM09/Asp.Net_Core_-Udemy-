using Microsoft.EntityFrameworkCore;
using revise.Middlewares;
using revise.Models;
using Services;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();/*
builder.Services.AddTransient<CustomMiddlware>();
builder.Services.AddTransient<LoginMiddleware>();*/
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddDbContext<BooksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
