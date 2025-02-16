using System.ComponentModel.DataAnnotations;

namespace New_Revision.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
      
        [StringLength(40)]
        public string? Title { get; set; }

        
    }
}
