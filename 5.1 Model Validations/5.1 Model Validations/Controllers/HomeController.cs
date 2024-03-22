using Microsoft.AspNetCore.Mvc;
using _5._1_Model_Validations.Models;

namespace _5._1_Model_Validations.Controllers
{
    [Route("/register")]
    public class HomeController : Controller
    {
        //public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))] Person person)
        //public IActionResult Index([FromBody] Person person) //To read json
        public IActionResult Index(Person person, [FromHeader(Name = "User-Agent")] string userAgent)  //To read header values
        {
            if (ModelState.IsValid)
            {
                return Content($"{person}");
            }

            //List<string> errorlist = new List<string>();
            string errors = string.Join("\n",
                ModelState.Values.SelectMany(value =>
                value.Errors).Select(err =>
                err.ErrorMessage));

            /*   foreach (var value in ModelState.Values)
               {
                   foreach (var error in value.Errors)
                   {
                       errorlist.Add(error.ErrorMessage);
                   }
               }*/
            //string errors = string.Join("\n", errorlist);
            return BadRequest(errors);
        }
    }
}
