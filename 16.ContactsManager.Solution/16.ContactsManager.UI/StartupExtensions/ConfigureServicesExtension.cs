using Filters.ActionFilters;
using Services;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Filters.ResultFilters;

namespace EntityFramerworkCore
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
            services.AddTransient<IPersonAdderService, PersonAdderService>();
            services.AddTransient<IPersonGetterService, PersonGetterService>();
            //services.AddTransient<IPersonGetterService, PersonsGetterServiceWithFiewExcelFields>();
            services.AddTransient<PersonsListResultFilter>();
           /* services.AddDbContext<PersonsDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));   //Connecting mssql server
            });*/
            return services;
        }
    }
}
