using _9._1_View_Component_Challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9._1_View_Component_Challenge.ViewComponents
{
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            return View(city);
        }
    }
}
