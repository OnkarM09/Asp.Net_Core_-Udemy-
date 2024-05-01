using _13._CRUD_Application.Models;
using _13._CRUD_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace _13._CRUD_Application.Controllers
{
    public class Persons : Controller
    {
        private readonly IPersonService _personService;

        public Persons(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<Person> persons = _personService.GetPersons();
            return View(persons);
        }

        [Route("[action]/{Id}")]
        public IActionResult EditPerson(int Id)
        {
            if(Id == null)
            {
                return Content("Person cannot be null");
            }
            Person p1 = _personService.GetPersonById(Id);
            return View(p1);
        }

        [Route("[action]/update")]
        [HttpPost]
        public IActionResult UpdatePerson(Person p)
        {
            _personService.UpdatePerson(p);
            return RedirectToAction("Index");
        }
    }
}
