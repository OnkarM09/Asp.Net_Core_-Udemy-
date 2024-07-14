using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace _15._EntityFramerworkCore.Controllers
{
    public class HomeController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            IExceptionHandlerPathFeature? exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if(exceptionHandler != null && exceptionHandler.Error != null)
            {
                ViewBag.ErrorMessage = exceptionHandler.Error.Message;
            }
            return View(); //Views / Shared/ Error
        }
    }
}
