using System.ComponentModel.DataAnnotations;

namespace MovieApi.Model
{
    public class Movie
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
        
        public int? Duration { get; set; }

    }
}
