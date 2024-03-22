using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using _4._Controllers.Models;

namespace _4._Controllers.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        /* [Route("/sayhello")]   //This is called as attribute routing
         [Route("/")]           //we can add multiple routing paths
         public string method1()
         {
             return "Hello from method 1";
         }*/

        [Route("/")]
        public string Index()
        {
            return "hello from index";
        }

        [Route("home")]
        public ContentResult Home()
        {
            /* return new ContentResult()
             {
                 Content = "This is from content result",
                 ContentType = "text/plain"
             };*/

            return Content("Plain text", "text/plain");
        }

        [Route("about-us")]
        public ContentResult About()
        {
            return Content("<h1>Hello from About</h1>", "text/html");
        }

        [Route("employee/{id=1}")]
        public string GetEmployeeId()
        {

            return "Id is 1";
        }
        //Json format
        [Route("userdetalis")]
        public JsonResult Person()
        {
            Users user1 = new Users()
            {
                Id = Guid.NewGuid(),
                Name = "Steven Smith",
                Age = 32
            };
            return new JsonResult(user1);   //Return JsonResult() will automatically set the content-type as application/json in the response header.
        }


        //File results
        //1. Virtual file result
        [Route("angular-notes")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/angular.pdf", "application/pdf");
            //Or
            return File("/angular.pdf", "application/pdf");
        }

        //When to use virtualFileResult = It can be used when your files are stored in the wwwroot folder.

        //2. Physical File Result
        //When your files sits outside of the wwwroot folder then use this method.
        [Route("gojo")]
        public PhysicalFileResult Filedownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\OnkarMeherwade\Downloads\gojo.jpg", "image/jpeg");
            return PhysicalFile(@"C:\Users\OnkarMeherwade\Downloads\gojo.jpg", "image/jpeg");
        }

        //3. FileContentResult
        //Reading the files from database such as bite array (Raw Data or Represents a fiel from the byte[])
        [Route("file-download")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\OnkarMeherwade\Downloads\gojo.jpg");
            /* return new FileContentResult(bytes, "image/jpeg");*/
            return File(bytes, "image/jpeg");
        }
        //Prefer shortcut return types in the real world projects.

        //IActionResult
        //As we can see from the above example we have to mention a return type and then return response with the same type.
        //We can use IActionResult instead.
        //IActionResult is the parent interface for all the action result classes such as ContentResult, JsonResult, RedirectResult, StatusCodeResult, ViewResult etc.
    }
}
