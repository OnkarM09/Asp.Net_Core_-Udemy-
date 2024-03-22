using _6._Views.Models;
using Microsoft.AspNetCore.Mvc;

namespace _6._Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["pageTitle"] = "Some page title";

            List<Person> persons = new List<Person>()
    {
       new Person {
                name = "Maverick",
                dateofbirth = Convert.ToDateTime("2022-01-01"),
                genderType = Gender.Male
            },
            new Person
            {
                   name = "Goose",
                dateofbirth = Convert.ToDateTime("2002-11-11"),
                genderType = Gender.Female
            }
    };
            //   ViewData["persons"] = persons; // We can also use Viewbag here for ex: 
            //ViewBag.persons = persons;
            //     return View(); //View name (cshtml)file name will be Index as action method's name
            //return new ViewResult() { ViewName = "abc" };

            //Strongly typed views
            //We can pass the model in return as,
            return View("Index", persons);
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Name can't be null");
            }
            List<Person> persons = new List<Person>()
    {
       new Person {
                name = "Maverick",
                dateofbirth = Convert.ToDateTime("2022-01-01"),
                genderType = Gender.Male
            },
            new Person
            {
                   name = "Goose",
                dateofbirth = Convert.ToDateTime("2002-11-11"),
                genderType = Gender.Female
            }
    };
            Person? matchedPerson = persons.Where(p => p.name == name).FirstOrDefault();
            return View(matchedPerson);

        }

        [Route("/person-product-details")]
        public IActionResult PesonAndProductDetails()
        {
            Person p1 = new Person()
            {
                name = "Steven Smith",
                dateofbirth = Convert.ToDateTime("2015-01-01"),
                genderType = Gender.Male    
            };

            Product pd1 = new Product()
            {
                productName = "From Australia",
                productType = "Batsman"
            };

            PersonAndProductModel pp1 = new PersonAndProductModel()
            {
                personData = p1,
                prdouctData = pd1
            };
            return View(pp1);
        }
    }
}
