using System.ComponentModel.DataAnnotations;

namespace _14._Tag_Helpers.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Name cannot be empty!")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Job cannot be empty!")]
        public string? Job { get; set; }
    }
}
