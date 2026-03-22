using MovieAccess.DataAccess.Data;
using MovieAccess.DataAccess.Models;
using MovieApp.DTOs;
using System.Text.Json;

public class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (context.Movie.Any())
            return;

        var json = await File.ReadAllTextAsync("moviedata2.json");

        var seedData = JsonSerializer.Deserialize<List<MovieSeedDTO>>(json);

        var movies = seedData?.Select(x => new Movie
        {
            Title = x.Title.ToString(),
            Year = x.Year,
            Directors = x.Directors,
            ReleaseDate = Convert.ToDateTime(x.ReleaseDate),
            Rating = x.Rating,
            Genres = x.Genres,
            ImageUrl = x.ImageUrl,
            Plot = x.Plot,
            Rank = x.Rank,
            Actors = x.Actors,
            RunningTime = TimeSpan.FromSeconds(x.RunningTimeSecs)
        }).ToList();

        if (movies != null)
        {
            context.Movie.AddRange(movies);
        }
        await context.SaveChangesAsync();
    }
}