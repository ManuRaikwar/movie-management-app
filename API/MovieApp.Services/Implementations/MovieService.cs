using AutoMapper;
using MovieAccess.DataAccess.Interfaces;
using MovieAccess.DataAccess.Models;
using MovieApp.Services.DTOs;
using MovieApp.Services.Interfaces;

namespace MovieApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> GetLatestMoviesAsync(int count)
        {
           var movies = await _movieRepository.GetAllAsync();

           var latestMovies = movies.OrderByDescending(m => m.ReleaseDate)
                .Take(count).ToList();

        return _mapper.Map<List<MovieDto>>(latestMovies);
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<List<MovieDto>>(movies);
        }

        public async Task<MovieDto?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return movie == null ? null : _mapper.Map<MovieDto>(movie);
        }

        public async Task AddMovieAsync(MovieCreateDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.AddAsync(movie);
        }

        public async Task<bool> UpdateMovieAsync(MovieUpdateDto movieDto)
        {
            var existing = await _movieRepository.GetByIdAsync(movieDto.Id);

            if (existing == null)
                return false;

            _mapper.Map(movieDto, existing);
            await _movieRepository.UpdateAsync(existing);
            return true;
        }       

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var existing = await _movieRepository.GetByIdAsync(id);

            if (existing == null)
                return false;

            await _movieRepository.DeleteByIdAsync(id);
            return true;
        }

        public async Task<List<MovieDto>> SearchMoviesAsync(string searchBy, string value)
        {
            var searchedMovies = await _movieRepository.SearchAsync(searchBy, value);
            return _mapper.Map<List<MovieDto>>(searchedMovies);
        }

    }
}
