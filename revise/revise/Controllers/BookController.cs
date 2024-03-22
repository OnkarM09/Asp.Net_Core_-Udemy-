using Microsoft.AspNetCore.Mvc;
using revise.Models;

namespace revise.Controllers
{
    public class BookController : Controller
    {
        [Route("/books")]
        public IActionResult Index()
        {
            Book book = new Book()
            {
                BookId = 1,
                Author = "Elon Musk"
            };
            return new JsonResult(book);
        }
    }
}
