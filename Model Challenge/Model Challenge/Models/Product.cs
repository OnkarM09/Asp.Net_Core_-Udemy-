using System.ComponentModel.DataAnnotations;

namespace Model_Challenge.Models
{
    public class Product
    {
   
        public int ProductCode { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
