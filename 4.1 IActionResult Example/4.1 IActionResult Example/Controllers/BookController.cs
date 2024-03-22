using Microsoft.AspNetCore.Mvc;

namespace _4._1_IActionResult_Example.Controllers
{
    public class BookController : Controller
    {
        //[Route("/bookstore")]  normal for query string 
        [Route("/bookstore/{bookid}/{isLoggedIn}")]   //This is for routing and route values

        //public IActionResult Index([FromRoute]int? bookid, [FromRoute] bool isLoggedIn) //To read these values from route values
        public IActionResult Index([FromQuery] int? bookid, [FromQuery] bool isLoggedIn)   //To read values from querystring
        {
            return Content($"{bookid} {isLoggedIn}");
        }
    }
}
