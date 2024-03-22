using Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Services;


namespace _10._1._Challenge_DI.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherService) { 
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            IEnumerable<CityWeather> cities = _weatherService.GetCities();
            return View(cities);
        }

        [Route("citydetails/{cityCode}")]
        public IActionResult GetCityDetails(string cityCode)
        {
            CityWeather city = _weatherService.CityDetails(cityCode);
            return View(city);
        }
    }
}
