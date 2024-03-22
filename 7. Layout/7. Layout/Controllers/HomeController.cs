using Microsoft.AspNetCore.Mvc;

namespace _7._Layout.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
