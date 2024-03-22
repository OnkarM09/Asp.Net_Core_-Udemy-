using Microsoft.AspNetCore.Mvc;

namespace _7._Layout.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("products-search/{ProductId?}")]
        public IActionResult Search(int? ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }
        [Route("products-order")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
