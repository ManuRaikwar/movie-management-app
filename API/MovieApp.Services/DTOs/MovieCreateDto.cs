using System.ComponentModel.DataAnnotations;

namespace MovieApp.Services.DTOs
{

    public class MovieCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Directors { get; set; } = string.Empty;

        [Required]
        public string Actors { get; set; } = string.Empty;

        [Required]
        public DateTime ReleaseDate { get; set; }

        public double Rating { get; set; }

        [Required]
        public string Genres { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string? Plot { get; set; }

        public int Rank { get; set; }

        [Required]
        public int RunningTime { get; set; }
    }
}
