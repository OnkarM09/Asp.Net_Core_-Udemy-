using System.Security.Principal;

namespace Controllers_Challenge
{
    public class BankDetails
    {
        public int? AccountNumber { get; set; }

        public string? AccountHolderName { get; set; }

        public int? currentBalance {  get; set; }
    }
}
