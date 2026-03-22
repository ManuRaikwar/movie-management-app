using MovieAccess.DataAccess.Models;
using MovieApp.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetLatestMoviesAsync(int count);
        Task<List<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto?> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieCreateDto movie);
        Task<bool> UpdateMovieAsync(MovieUpdateDto movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<List<MovieDto>> SearchMoviesAsync(string searchBy, string value);
    }
}
