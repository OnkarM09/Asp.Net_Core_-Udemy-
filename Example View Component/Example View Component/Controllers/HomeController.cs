using Example_View_Component.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Example_View_Component.Controllers
{
    public class HomeController : Controller

    {
        private readonly IPersons _persons;
        List<Person> persons = new List<Person>()
            {
                new Person()
                {
                    name = "John",
                    email = "john@example.com"
                },
                new Person()
                {
                    name = "Wick",
                    email = "wick@example.com"
                }
            };

        public HomeController(IPersons persons)
        {
            _persons = persons;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View(persons);
        }
        [Route("get-persons")]
        public IActionResult GetPersons()
        {
            return ViewComponent("GetPersons", new
            {
                persons = persons
            });
        }
        [Route("get-service-persons")]
        public IActionResult GetServicePerson()
        {
            List<string> p = _persons.GetPersons();
            return View(p);
        }
    }
}
