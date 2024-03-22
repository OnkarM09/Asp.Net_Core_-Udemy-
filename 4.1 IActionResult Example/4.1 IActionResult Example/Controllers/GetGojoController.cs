using Microsoft.AspNetCore.Mvc;

namespace _4._1_IActionResult_Example.Controllers
{
    public class GetGojoController : Controller
    {
        [Route("jjk/gojo-satoru")]
        public IActionResult GojoSensei()
        {
            return Content("<h1>Gojo Saturou</h1>");
        }
    }
}
