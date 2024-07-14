using _15._EntityFramerworkCore.Filters.ActionFilters;
using _15._EntityFramerworkCore.Filters.ResultFilters;
using _15._EntityFramerworkCore.Models;
using _15._EntityFramerworkCore.Services;
using Microsoft.EntityFrameworkCore;

namespace _15._EntityFramerworkCore
{
    public static class ConfigureServicesExtension 
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)   //Extension method
        {
            services.AddControllersWithViews(options =>
            {
                //options.Filters.Add<ResponseHeaderActionFilter>();   //Adding filter globally  for entire project  
                //How to add arguments in this case?

                //We have to use different way
                //  var logger = services.BuildServiceProvider().GetRequiredService<ILogger<ResponseHeaderActionFilter>>();
                options.Filters.Add(new ResponseHeaderActionFilter("my-global-key", "my-global-value", 2));
            });
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonAdderService, PersonAdderService>();
            services.AddTransient<IPersonAdderService, PersonsAdderServiceChild>();
            services.AddTransient<IPersonGetterService, PersonGetterService>();
            services.AddTransient<IPersonGetterService, PersonsGetterServiceWithFiewExcelFields>();
            services.AddTransient<PersonsListResultFilter>();
            services.AddDbContext<PersonsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));   //Connecting mssql server
            });
            return services;
        }
    }
}
