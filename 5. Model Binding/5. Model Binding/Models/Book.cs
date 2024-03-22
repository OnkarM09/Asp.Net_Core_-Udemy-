using Microsoft.AspNetCore.Mvc;

namespace _5._Model_Binding.Models
{
    public class Book
    {
        //[FromQuery]
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book Id : {BookId}, Author Id : {Author}";
        }

    }
}
