using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieAccess.DataAccess.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Actors cannot be empty")]
        public string Directors { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        [Required]
        public string Genres { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? Plot { get; set; }
        public int Rank { get; set; }
        public TimeSpan RunningTime { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Directors cannot be empty")]
        public string Actors { get; set; } = string.Empty;

    }
}
