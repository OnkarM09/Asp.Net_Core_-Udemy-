using Microsoft.AspNetCore.Mvc;
using New_Revision.Models;
using New_Revision.Serivices;

namespace New_Revision.Controllers
{
    [Controller]
    public class HomeController : Controller
    {

        private readonly IHeroService _heroService;

        public HomeController(IHeroService heroservice) {
            _heroService = heroservice;
        }


        [Route("/")]
        public  async Task<IActionResult> Index()
        {
            List<Hero> heroes = await _heroService.GetHeroesList();
            return View(heroes);
        }

        [Route("get-person/{name}")]
        public IActionResult GetPerson(string? name)
        {
            ViewData["Title"] = "Deatails Page";
            List<Person> p = new List<Person>() {
            new Person() {
                Id = 1,
                Name = "John Wick",
            },
            new Person()
            {
                Id = 2,
                Name = "John Smith",
            }
            };

            if(name == null)
            {
                return BadRequest("Please provide last name");
            }

            Person? matchedPerson = p.Where(person => person.Name == name).FirstOrDefault();
            if(matchedPerson == null)
            {
                return BadRequest("The person is not a valid person");
            }
            return View(matchedPerson);
        }

        [Route("create/hero")]
        public IActionResult CreateHero()
        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> NewHero(Hero hero)
        {
            await _heroService.SaveHero(hero);
            return RedirectToAction("Index");
        }
    }
}
