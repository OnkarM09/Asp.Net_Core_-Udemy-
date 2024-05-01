using _15._EntityFramerworkCore.Models;
using _15._EntityFramerworkCore.Services;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;

namespace _15._EntityFramerworkCore.Controllers
{
    public class PersonsController : Controller
    {

        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            List<Person> persons = await _personService.GetPersons();
            return View(persons);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            await _personService.AddPersonToDb(person);
            return RedirectToAction("Index");
        }

        [Route("create/person")]
        public IActionResult CreatePersonForm()
        {
            return View();
        }

        [Route("[action]/{Id}")]
        public async Task<IActionResult> EditPerson(int Id)
        {
            if (Id == null)
            {
                return Content("Person cannot be null");
            }
            Person p1 = await _personService.GetPersonById(Id);
            return View(p1);
        }

        [Route("PersonsPDF")]
        public async Task<IActionResult> PersonsPDF()
        {
            //Get list of persons
            List<Person> persons = await _personService.GetPersons();
            return new ViewAsPdf("PersonsPDF", persons, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top =20, Right =20, Bottom =20, Left =20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }
    }
}
