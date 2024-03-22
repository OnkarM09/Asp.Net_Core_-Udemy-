using Microsoft.AspNetCore.Mvc;
using _5._Model_Binding.Models;

namespace _5._Model_Binding.Controllers
{
    public class BookController : Controller
    {
        //[Route("/bookstore")]  normal for query string 
        [Route("/bookstore/{bookid}/{isLoggedIn}")]   //This is for routing and route values

        //public IActionResult Index([FromRoute]int? bookid, [FromRoute] bool isLoggedIn) //To read these values from route values
        public IActionResult Index( int? bookid, bool isLoggedIn, Book book)   //To read values from querystring
        {
           
            return Content($"{bookid} {isLoggedIn}\n {book}");
        }
    }
}
