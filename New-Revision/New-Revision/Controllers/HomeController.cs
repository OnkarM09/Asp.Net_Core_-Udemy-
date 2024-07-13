using Microsoft.AspNetCore.Mvc;
using New_Revision.Filters.ActionFilters;
using New_Revision.Models;
using New_Revision.Serivices;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace New_Revision.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroService _heroService;

        public HomeController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [Route("/")]
        [Route("GetHeroes")]
        [TypeFilter(typeof(HeroesListActionFilter))]
        public async Task<IActionResult> Index()
        {
            List<Hero> heroes = await _heroService.GetHeroesList();
            return View(heroes);
        }

        [Route("CreateHero")]
        [HttpGet]
        public IActionResult CreateHero()
        {
            return View();
        }
        [Route("SaveHero")]
        [HttpPost]
        public async Task<IActionResult> SaveHero(Hero hero) {
            await _heroService.SaveHero(hero);
            return RedirectToAction("Index");
        }

        [Route("GetHeroById/{Id}")]
        [HttpGet]
        public async Task<IActionResult> GetHeroById(int Id)
        {
            Hero hero = await _heroService.GetHeroById(Id);
            return View(hero);
        }

        [Route("UpdateHero")]
        [HttpPost]
        public async Task<IActionResult> UpdateHero(Hero hero)
        {
            await _heroService.UpdateHero(hero);
            return RedirectToAction("Index");
        }


    }
}
