using Microsoft.AspNetCore.Mvc;
using Models;

namespace _10._1._Challenge_DI.ViewComponents
{
    public class CityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather city)
        {
            return View(city);
        }
    }
}
