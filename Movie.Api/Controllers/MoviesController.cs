using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos.Movie;
using Movie.Application.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieReadDto>>> GetMovies(int pageNumber = 1, int pageSize = 10, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null)
        {
            var movies = await _movieService.GetMoviesAsync(pageNumber, pageSize, name, genre, director, actor);

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDetailsDto>> GetMovieById(Guid id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            return movie == null ? NotFound() : Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieReadDetailsDto>> AddMovie(MovieCreateDto movieDto)
        {
            var createdMovie = await _movieService.AddMovieAsync(movieDto);

            return CreatedAtAction(nameof(GetMovieById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieReadDetailsDto>> UpdateMovie(Guid id, MovieUpdateDto movieDto)
        {
            var updatedMovie = await _movieService.UpdateMovieAsync(id, movieDto);

            return updatedMovie == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMovie(Guid id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            return result == false ? NotFound() : NoContent();
        }
    }
}
