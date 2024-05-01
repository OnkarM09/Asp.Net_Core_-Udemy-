using System.ComponentModel.DataAnnotations;

namespace _13._CRUD_Application.Models
{
    public class Person
    {
        [Required(ErrorMessage ="This field cannot be empty")]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
