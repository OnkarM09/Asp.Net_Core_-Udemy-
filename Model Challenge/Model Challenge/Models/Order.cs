using Model_Challenge.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace Model_Challenge.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }
        [Required(ErrorMessage = "{0} is invalid!")]
        [MinimumDateValidator("2000-01-01")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "{0} is invalid!")]
        public double InvoicePrice { get; set; }
        [ProductListValidator]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
