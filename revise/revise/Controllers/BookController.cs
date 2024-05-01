using Microsoft.AspNetCore.Mvc;
using revise.Models;
using Services;

namespace revise.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("/books")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.userId = _bookService.userId;
            IEnumerable <Book> books = _bookService.AllBooks();
            return View(books);
        }
    }
}
