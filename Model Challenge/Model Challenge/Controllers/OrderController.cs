using Microsoft.AspNetCore.Mvc;
using Model_Challenge.Models;

namespace Model_Challenge.Controllers
{
    public class OrderController : Controller
    {
        [Route("order")]
        public IActionResult Index(Order order)
        {
            if (ModelState.IsValid)
            {
                if (Request.Method == "POST")
                {
                    Random rand = new Random();
                    int orderNum = rand.Next(0, 100);

                    return Content($"Order number is {orderNum}");
                }
            }

            string errorMsg = string.Join("\n", ModelState.Values.SelectMany( v => v.Errors).Select(e => e.ErrorMessage)); 

            return BadRequest(errorMsg);
        }
    }
}
