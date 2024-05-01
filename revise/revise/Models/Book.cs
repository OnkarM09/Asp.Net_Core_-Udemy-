using System.ComponentModel.DataAnnotations;

namespace revise.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string? Author { get; set; }
    }
}
