using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Directors { get; set; } = string.Empty;   
        public string Actors { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public string Genres { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
