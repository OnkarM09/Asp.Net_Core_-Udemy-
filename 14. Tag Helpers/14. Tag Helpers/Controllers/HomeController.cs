using _14._Tag_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _14._Tag_Helpers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            List<Anime> animes = new List<Anime>()
            {
                new Anime()
                {
                    Name = "Fullmental Alchemist",
                    Value = 1
                },
                new Anime()
                {
                    Name = "Dragon Ball Z",
                    Value = 2
                },
                new Anime()
                {
                    Name = "Naruto",
                    Value = 3
                },
            };
            ViewBag.AllAnimes = animes.Select(anime => new SelectListItem()
            {
                Text = anime.Name,
                Value = anime.Value.ToString()
            });
            Person p1 = new Person()
            {
                Name = "John Wick",
                Job = "Killer"
            };

            return View(p1);
        }

        [Route("Home/GetPersonDetails")]
        [HttpPost]
        public IActionResult GetPersonDetails(Person person)
        {
            return View(person);
        }

        [Route("[action]/{personName}")]
        public IActionResult Edit(string personName)
        {
            Person p1 = new Person()
            {
                Name="John wick",
                Job = "Killer"
            };
            return View(p1);
        }
    }
}
