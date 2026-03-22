using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieApp.DTOs
{
    public class MovieSeedDTO
    {
        public JsonElement Title { get; set; }
        public int Year { get; set; }
        public string Directors { get; set; } = string.Empty;
        [JsonPropertyName("Release Date")]
        public string ReleaseDate { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Genres { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? Plot { get; set; } 
        public int Rank { get; set; }

        [JsonPropertyName("Running Time (secs)")]
        public int RunningTimeSecs { get; set; }

        public string Actors { get; set; } = string.Empty;
    }
}
