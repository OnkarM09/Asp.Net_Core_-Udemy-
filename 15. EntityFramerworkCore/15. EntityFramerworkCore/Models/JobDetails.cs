using System.ComponentModel.DataAnnotations;

namespace _15._EntityFramerworkCore.Models
{
    public class JobDetails
    {
        [Key]
        public string? JobTitle { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<Person>? Persons { get; set; }
    }
}
