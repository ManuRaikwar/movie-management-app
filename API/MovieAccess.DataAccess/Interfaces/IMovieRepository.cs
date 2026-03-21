using MovieAccess.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteByIdAsync(int id);
    }
}
