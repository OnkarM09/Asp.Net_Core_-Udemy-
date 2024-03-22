using Microsoft.AspNetCore.Mvc;

namespace _4._1_IActionResult_Example.Controllers
{
    public class HomeController : Controller
    {
        [Route("getgojo")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("value"))
            {
                /*  Response.StatusCode = 400;
                  return Content("Value is not present");*/
                //return new BadRequestResult(); or
                return BadRequest("Value is not present");
            }

            if (string.IsNullOrEmpty(Request.Query["value"]))
            {
                return BadRequest("Value cannot be empty!");
            }

            if (Convert.ToInt32(Request.Query["value"]) <= 0)
            {
                return BadRequest("Value should not be less than or equal to 0");
            }

            if (Convert.ToInt32(Request.Query["value"]) > 1000)
            {
                return NotFound("Book value should not be greater than 1000");
            }

            if (!Convert.ToBoolean(Request.Query["cansee"]))
            {
                /* Response.StatusCode = 401;
                 return Content("You cannot see the content");*/
                //return Unauthorized("You cannot see the content");
                return StatusCode(401);
            }
            //return new RedirectToActionResult("GojoSensei", "GetGojo", new { }); //302 - found //First argument is action method and 2nd argument is the controller name where that actions is and dont use controller postfix and third argument is route parameter
            //return new RedirectToActionResult("GojoSensei", "GetGojo", new { }, true);  //true -> 301 = moved parmenantly

            //Shortcuts redirection
            //for 302
            //return RedirectToAction("GojoSensei", "GetGojo", new { });

            //For 301
            //return RedirectToActionPermanent("GojoSensei", "GetGojo", new { });

            return new LocalRedirectResult("jjk/gojo-satoru");   //make true as a second argument for 301
        }     
    }
}
