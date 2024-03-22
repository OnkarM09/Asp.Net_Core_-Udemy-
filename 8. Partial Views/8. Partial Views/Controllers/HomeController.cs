using _8._Partial_Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace _8._Partial_Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItems"] = new List<string>()
            {
                "Paris",
                "London",
                "New York",
                "Mumbai",
                "Shanghai",
                "Tokyo",
                "Capetown",
                "Spain"
            };

            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-lang")]
        public IActionResult ProgammingLanguages()
        {
            ListModel listModel = new ListModel()
            {
                ListTitle = "Best Programming Languages",
                ListItems = new List<string>()
                {
                    "Javascript",
                    "Typescript",
                    "C Sharp"
                }
            };
            //return new PartialViewResult() { ViewName = "_ListPartialView", Model = listModel };
            return PartialView("_ListPartialView", listModel);
        }
    }
}
