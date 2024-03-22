using _9._View_Component.Models;
using Microsoft.AspNetCore.Mvc;

namespace _9._View_Component.Controllers
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

        [Route("/load-friends-list")]
        public IActionResult Friends()
        {
            PersonGrid PersonGrid = new PersonGrid()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>
                {
                    new Person()
                    {
                        PersonName = "John Wick",
                        JobTitle = "Professional Killer"
                    },
                      new Person()
                    {
                        PersonName = "Uchiha Obito",
                        JobTitle = "Hokage"
                    }
                }
            };
            return ViewComponent("Grid", new
            {
                grid  = PersonGrid
            });
        }
    }
}
