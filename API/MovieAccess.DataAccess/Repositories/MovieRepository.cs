using Microsoft.EntityFrameworkCore;
using MovieAccess.DataAccess.Data;
using MovieAccess.DataAccess.Enums;
using MovieAccess.DataAccess.Interfaces;
using MovieAccess.DataAccess.Models;

namespace MovieAccess.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {   
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movie.FindAsync(id);
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movie.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }


        //we can optimize it to handle generic search criteria instead of harcoding the if conditions
        public async Task<List<Movie>> SearchAsync(string searchBy, string value)
        {
            var query = _context.Movie.AsQueryable();

            if (searchBy.Equals(MovieSearchType.Title.ToString(), StringComparison.OrdinalIgnoreCase))
                query = query.Where(m => m.Title.ToLower().Contains(value.ToLower()));

            if (searchBy.Equals(MovieSearchType.Genre.ToString(), StringComparison.OrdinalIgnoreCase))
                query = query.Where(m => m.Genres.ToLower().Contains(value.ToLower()));

            if (searchBy.Equals(MovieSearchType.Year.ToString(), StringComparison.OrdinalIgnoreCase) && int.TryParse(value, out int year))
                query = query.Where(m => m.Year == year);

            return await query.ToListAsync();
        }

    }
}
