using System.ComponentModel.DataAnnotations;

namespace New_Revision.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [Display(Name = "Person Name")]
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"The Id is : {Id} and the name is: {Name}";
        }

    }
}
