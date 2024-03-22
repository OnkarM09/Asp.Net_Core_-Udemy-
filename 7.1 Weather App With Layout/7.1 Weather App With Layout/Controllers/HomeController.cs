using _7._1_Weather_App_With_Layout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace _7._1_Weather_App_With_Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<CityWeather> cities = new List<CityWeather>()
        {
            new CityWeather(){
                CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33
            },
             new CityWeather(){
                CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheit = 60
            },
            new CityWeather(){
               CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82
            },
        };

        [Route("/")]
        public IActionResult Index()
        {
            return View(cities);
        }

        [Route("/CityDetails/{CityUniqueCode}")]
        public IActionResult CityDetails(string? CityUniqueCode)
        {
            if (string.IsNullOrEmpty(CityUniqueCode))
            {
                return Content("Invalid City or Null!");
            }

            CityWeather matchedCity = cities.Where(c => c.CityUniqueCode ==  CityUniqueCode).FirstOrDefault();
            return View(matchedCity);
        }
    }
}
