using AutoMapper;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using MovieAccess.DataAccess.Interfaces;
using MovieAccess.DataAccess.Models;
using MovieApp.Services.DTOs;
using MovieApp.Services.Implementations;
using MovieApp.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;
using Xunit;


namespace MovieApp.Tests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _repoMock;
        private readonly MovieService _service;
        private IMapper _mapper;

        public MovieServiceTests()
        {
            // Mock repository
            _repoMock = new Mock<IMovieRepository>();

            // Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MovieCreateDto, Movie>()
                   .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RunningTime)))
                   .ReverseMap()
                   .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => src.RunningTime.TotalSeconds));
                cfg.CreateMap<MovieUpdateDto, Movie>()
                   .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => TimeSpan.FromSeconds(src.RunningTime)))
                   .ReverseMap()
                   .ForMember(dest => dest.RunningTime, opt => opt.MapFrom(src => src.RunningTime.TotalSeconds));
            });
            _mapper = config.CreateMapper(); // <- initialize mapper

            // Create service with mapper
            _service = new MovieService(_repoMock.Object, _mapper);
        }

        [Fact]
        public async Task GetAllMovies_ReturnsListOfMovies()
        {
            var mockMovies = LoadMockMovies();
            _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(mockMovies);

            // Act
            var result = await _service.GetAllMoviesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
        }

        [Fact]
        public async Task AddMovie_CallsRepository()
        {
            var mockMovies = LoadMockMovies();
            var movie = mockMovies.First();
            


            var movieCreateDto = _mapper.Map<MovieCreateDto>(movie);
            await _service.AddMovieAsync(movieCreateDto);


            _repoMock.Verify(r => r.AddAsync(It.Is<Movie>(m => m.Title == movie.Title)), Times.Once);

        }

        [Fact]
        public async Task DeleteMovie_CallsRepository()
        {
            // Arrange
            var mockMovies = LoadMockMovies();
            var movieToDelete = mockMovies.First();
            int movieId = movieToDelete.Id;

            // Setup repository to find the movie by Id
            _repoMock.Setup(r => r.GetByIdAsync(movieId)).ReturnsAsync(movieToDelete);
            _repoMock.Setup(r => r.DeleteByIdAsync(movieId)).Returns(Task.CompletedTask);

            // Act
            await _service.DeleteMovieAsync(movieId);

            // Assert
            _repoMock.Verify(r => r.DeleteByIdAsync(movieId), Times.Once);
        }

        [Fact]
        public async Task UpdateMovie_CallsRepositoryAndUpdatesProperties()
        {
            // Arrange
            var mockMovies = LoadMockMovies();
            var existingMovie = mockMovies.First();
            int movieId = existingMovie.Id;

            var updateDto = new MovieUpdateDto
            {
                Title = "Gettysburg - Director's Cut",
                ReleaseDate = existingMovie.ReleaseDate,
                Rating = 8.0,
                Rank = existingMovie.Rank,
                RunningTime = (int)existingMovie.RunningTime.TotalSeconds,
                Actors = existingMovie.Actors
            };

            _repoMock.Setup(r => r.GetByIdAsync(movieId)).ReturnsAsync(existingMovie);
            _repoMock.Setup(r => r.UpdateAsync(It.IsAny<Movie>())).Returns(Task.CompletedTask);

            // Act
            await _service.UpdateMovieAsync(updateDto);

            // Assert
            _repoMock.Verify(r => r.UpdateAsync(It.Is<Movie>(m =>
                m.Id == movieId &&
                m.Title == updateDto.Title &&
                m.Rating == updateDto.Rating)), Times.Once);
        }

        private List<Movie> LoadMockMovies()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "MockData", "Movies.json");
            var json = File.ReadAllText(path);

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

            return movies ?? new List<Movie>();
        }
    }
}
