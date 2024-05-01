using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _12._Configuration.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Weather _weatherApiOptions;
        
        //public HomeController(IConfiguration configuration) {  //Instead of using this we are using Configuration as service so,
        public HomeController(IOptions<Weather> weatherApiOptions) {
            _weatherApiOptions = weatherApiOptions.Value;  //Getting valuse of WeatherApiConfigureation such as id and url
        }

        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration["MyVal"];
        //    ViewBag.MyApiKey = _configuration.GetValue("MyApiKey", "Default Value");

            //Hierarchical Configuration
            //ViewBag.WeatherId = _configuration.GetValue("WeatherApi:id", "1");
            //ViewBag.WeatherUrl = _configuration.GetValue("WeatherApi:url", "2");

            //Alternate way
            /*            IConfigurationSection weatherSection = _configuration.GetSection("WeatherApi");
                        ViewBag.WeatherId = weatherSection["id"];
                        ViewBag.WeatherUrl = _configuration.GetSection("WeatherApi")["url"];*/

            //Options Pattern 
            //Loads value into weatherSection object
            //Weather weatherSection = _configuration.GetSection("WeatherApi").Get<Weather>();
            //ViewBag.WeatherId = weatherSection.id;
            //ViewBag.WeatherUrl = weatherSection.url;

            //Bind method
            //This will create object of Weather first and loads configuration values into that object.
            //For example
            /*Weather weatherOptions = new Weather();
            _configuration.GetSection("WeatherApi").Bind(weatherOptions);
            ViewBag.WeatherId = weatherOptions.id;
            ViewBag.WeatherUrl = weatherOptions.url;
*/
            //Configuration as a service 
            ViewBag.WeatherId = _weatherApiOptions.id;
            ViewBag.WeatherUrl = _weatherApiOptions.url;
            //This is the best way to get configuration values as our action method is clean 

            return View();
        }
    }
}
