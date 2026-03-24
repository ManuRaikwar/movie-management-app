using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAccess.DataAccess.Models;
using MovieApp.Services.DTOs;
using MovieApp.Services.Interfaces;

namespace MovieApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController: ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatestMoviesAsync([FromQuery] int count)
        {
            var latestMovies = await _movieService.GetLatestMoviesAsync(count);
            return Ok(latestMovies);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null) 
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync([FromBody] MovieCreateDto movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _movieService.AddMovieAsync(movie);

            return StatusCode(StatusCodes.Status201Created, movie);
            //return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, [FromBody] MovieUpdateDto movie)
        {
            if (id != movie.Id) 
                return BadRequest();

            var updated = await _movieService.UpdateMovieAsync(movie);

            if (!updated) 
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var deleted = await _movieService.DeleteMovieAsync(id);

            if (!deleted) return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMoviesAsync([FromQuery] string searchBy, [FromQuery] string value)
        {
            var movies = await _movieService.SearchMoviesAsync(searchBy, value);
            return Ok(movies);
        }
    }
}
