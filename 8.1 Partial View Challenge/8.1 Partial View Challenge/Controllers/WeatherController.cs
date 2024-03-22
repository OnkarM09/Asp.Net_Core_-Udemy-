using _8._1_Partial_View_Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8._1_Partial_View_Challenge.Controllers
{
    public class WeatherController : Controller
    {
        private List<CityWeatherModel> cities = new List<CityWeatherModel>() {
            new CityWeatherModel(){
                CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheit = 33
            },
            new CityWeatherModel()
            {
                CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime( "2030-01-01 3:00"),  TemperatureFahrenheit = 60
            },
               new CityWeatherModel()
            {
               CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheit = 82
            }
            };

        [Route("/")]
        public IActionResult Index()
        {
            return View(cities);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult CityWeatherDetails(string? cityCode)
        {
            if (string.IsNullOrEmpty(cityCode))
            {
                return View();
            }
            CityWeatherModel? city = cities.Where(temp => temp.CityUniqueCode == cityCode).FirstOrDefault();
            return View(city);
        }
    }
}
