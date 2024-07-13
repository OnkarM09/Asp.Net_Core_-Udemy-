using System.ComponentModel.DataAnnotations;

namespace New_Revision.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Key]
        [StringLength(40)]
        public string? Title { get; set; }

        
    }
}
