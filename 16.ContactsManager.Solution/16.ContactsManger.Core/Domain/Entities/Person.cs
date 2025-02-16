using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16.ContactsManger.Core.Domain.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [StringLength(40)]  //db type nvarchar with length of 40 characters otherwise upto 1billion characters
        public string? Name { get; set; }
        [StringLength(40)]
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        //Adding new column (Property) in the exisiting database of persons
        public string? Gender { get; set; }
        public string? JobTitle { get; set; }

        [ForeignKey("JobTitle")]
        public virtual JobDetails? JobDetails { get; set; }

    }
}
