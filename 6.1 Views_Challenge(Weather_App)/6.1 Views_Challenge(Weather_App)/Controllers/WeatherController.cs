using _6._1_Views_Challenge_Weather_App_.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace _6._1_Views_Challenge_Weather_App_.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeather> cities = new List<CityWeather>() {
    new CityWeather() { CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"), TempFerhinite = 33 },

    new CityWeather() { CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"), TempFerhinite = 60 },

    new CityWeather() { CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"), TempFerhinite = 82 }
   };
        [Route("/")]
        public IActionResult Index()
        {
            return View(cities);
        }

        [Route("/weather/{citycode}")]
        public IActionResult CityDetails(string? citycode)
        {
            if (String.IsNullOrEmpty(citycode))
            {
                return Content("Citycode cannot be empty!");
            }

            CityWeather matchedCity = cities.Where( c => c.CityUniqueCode == citycode ).FirstOrDefault();
            if(matchedCity != null)
            {

            return View(matchedCity);
            }
            return Content("No city matched!");
        }
    }
}
