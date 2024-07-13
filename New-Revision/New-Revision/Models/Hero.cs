using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_Revision.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(40)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(40)]
        public string? Power { get; set; }

        public int Rank { get; set; }

    }
}
