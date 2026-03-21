using MovieAccess.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeletMovieAsync(int id);
    }
}
