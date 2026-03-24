using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAccess.DataAccess.Models;
using MovieApp.Controllers;
using MovieApp.Services.DTOs;
using MovieApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MovieApp.Tests
{
    public class MovieControllerTests
    {
        private readonly Mock<IMovieService> _serviceMock;
        private readonly MovieController _controller;

        public MovieControllerTests()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new MovieController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetAllMovies_ReturnsOkWithMovies()
        {
            var mockMovies = new List<MovieDto>
        {
            new MovieDto { Id = 1, Title = "Test 123" }
        };

            _serviceMock.Setup(s => s.GetAllMoviesAsync())
                        .ReturnsAsync(mockMovies);

            // Act
            var result = await _controller.GetAllMoviesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var movies = Assert.IsAssignableFrom<List<MovieDto>>(okResult.Value);

            Assert.Single(movies);
            Assert.Equal("Test 123", movies[0].Title);
        }

        [Fact]
        public async Task GetMovieById_ReturnsOk_WhenMovieExists()
        {
            var movie = new MovieDto { Id = 1, Title = "Movie1" };

            _serviceMock.Setup(s => s.GetMovieByIdAsync(1))
                        .ReturnsAsync(movie);

            var result = await _controller.GetMovieAsync(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedMovie = Assert.IsType<MovieDto>(okResult.Value);

            Assert.Equal(1, returnedMovie.Id);
        }

        [Fact]
        public async Task GetMovieById_ReturnsNotFound_WhenMovieDoesNotExist()
        {
            _serviceMock.Setup(s => s.GetMovieByIdAsync(1))
                        .ReturnsAsync((MovieDto)null);

            var result = await _controller.GetMovieAsync(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddMovie_ReturnsOk_AndCallsService()
        {
            var movieDto = new MovieCreateDto { Title = "New Movie", RunningTime = 120 };

            _serviceMock.Setup(s => s.AddMovieAsync(movieDto))
                        .Returns(Task.CompletedTask);

            var result = await _controller.AddMovieAsync(movieDto);

            Assert.IsType<ObjectResult>(result);
            _serviceMock.Verify(s => s.AddMovieAsync(movieDto), Times.Once);
        }

        [Fact]
        public async Task UpdateMovie_ReturnsOk_AndCallsService()
        {
            var movieId = 1;
            var updateDto = new MovieUpdateDto { Id = 1, Title = "Updated Movie", RunningTime = 150 };

            _serviceMock.Setup(s => s.UpdateMovieAsync(updateDto))
                        .ReturnsAsync(true);

            var result = await _controller.UpdateMovieAsync(movieId, updateDto);

            Assert.IsType<OkResult>(result);
            _serviceMock.Verify(s => s.UpdateMovieAsync(updateDto), Times.Once);
        }

        [Fact]
        public async Task DeleteMovie_ReturnsOk_AndCallsService()
        {
            var movieId = 1;

            _serviceMock.Setup(s => s.DeleteMovieAsync(movieId))
                        .ReturnsAsync(true);

            var result = await _controller.DeleteMovieAsync(movieId);

            Assert.IsType<NoContentResult>(result);
            _serviceMock.Verify(s => s.DeleteMovieAsync(movieId), Times.Once);
        }
    }
}
