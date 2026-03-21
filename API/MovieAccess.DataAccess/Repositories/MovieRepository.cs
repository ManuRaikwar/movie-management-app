using MovieAccess.DataAccess.Interfaces;
using MovieAccess.DataAccess.Models;

namespace MovieAccess.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {        
        public async Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
