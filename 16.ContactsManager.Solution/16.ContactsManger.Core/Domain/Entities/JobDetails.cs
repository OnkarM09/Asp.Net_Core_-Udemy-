using System.ComponentModel.DataAnnotations;

namespace _16.ContactsManger.Core.Domain.Entities
{
    public class JobDetails
    {
        [Key]
        public string? JobTitle { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<Person>? Persons { get; set; }
    }
}
