using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();
/*builder.Services.Add(new ServiceDescriptor(
   typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Scoped
    )); */

//Easy way to do above code
//builder.Services.AddTransient<ICitiesService, CitiesService>();
//builder.Services.AddSingleton<ICitiesService, CitiesService>();
//builder.Services.AddScoped<ICitiesService, CitiesService>();

builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterType<CitiesService>().As<ICitiesService>()
    .InstancePerDependency();   //Equivalent to transient

  //  container.RegisterType<CitiesService>().As<ICitiesService>()
  //.InstancePerLifetimeScope(); //Equivalent to scoped

  //  container.RegisterType<CitiesService>().As<ICitiesService>()
  //.SingleInstance(); //Equivalent to single instance
});

//builder.Services in an IoC container which is Inversion of Control 
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
