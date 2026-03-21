using MovieAccess.DataAccess.Models;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {      
        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }       

        public async Task DeletMovieAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
