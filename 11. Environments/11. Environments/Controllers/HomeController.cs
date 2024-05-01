using Microsoft.AspNetCore.Mvc;

namespace _11._Environments.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment; // Whatever we can do with app.Environment in program file, same we can do using this.

        //Constructor 
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        //Adding some code to cause exception handling for app to check for dev and staging env.
        public IActionResult Index()
        {
           ViewBag.EnvName =  _webHostEnvironment.EnvironmentName;
            return View();
        }
    }
}
