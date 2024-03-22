using Microsoft.AspNetCore.Mvc;

namespace Controllers_Challenge.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Content("Welcome to the best bank!");
        }
        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            BankDetails bank1 = new BankDetails
            {
                AccountNumber = 1024,
                AccountHolderName = "Onkar Meherwade",
                currentBalance = 5000
            };

            return new JsonResult(bank1);
        }
        [Route("/account-statement")]
        public IActionResult AccountStatement()
        {
            return new VirtualFileResult("/Angular2NotesForProfessionals.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            if (Request.RouteValues.ContainsKey("accountNumber"))
            {

            int accountNum = Convert.ToInt32(Request.RouteValues["accountNumber"]);
            if (accountNum == 1001)
            {
                return Content("5000");
            }
            return BadRequest("Please check account number!");
            }
            else
            {
                return BadRequest("No account number found!");
            }
        }
    }
}
