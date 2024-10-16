using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Movie.Application.Dtos.MovieGenre;
using Movie.Application.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenresController : ControllerBase
    {
        private readonly IMovieGenreService _movieGenreService;
        public MovieGenresController(IMovieGenreService movieGenreService)
        {
            _movieGenreService = movieGenreService;
        }

        [HttpGet]
        public async Task<ActionResult<MovieGenreReadDto>> GetMovieGenres(int pageNumber = 1, int pageSize = 10, Guid? movieId = null, Guid? genreId = null)
        {
            var movieGenres = await _movieGenreService.GetMovieGenresAsync(pageNumber, pageSize, movieId, genreId);

            return Ok(movieGenres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGenreReadDetailsDto>> GetMovieGenreById(Guid id)
        {
            var movieGenre = await _movieGenreService.GetMovieGenreByIdAsync(id);

            return Ok(movieGenre);
        }

        [HttpPost]
        public async Task<ActionResult<MovieGenreReadDto>> AddMovieGenre(MovieGenreCreateDto movieGenreDto)
        {
            var addedMovieGenre = await _movieGenreService.AddMovieGenreAsync(movieGenreDto);

            return CreatedAtAction(nameof(GetMovieGenreById), new { id = addedMovieGenre.Id }, addedMovieGenre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieGenreReadDto>> UpdateMovieGenre(Guid id, MovieGenreUpdateDto movieGenreDto)
        {
            var updatedMovieGenre = await _movieGenreService.UpdateMovieGenreAsync(id, movieGenreDto);

            return updatedMovieGenre == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMovieGenre(Guid id)
        {
            var result = await _movieGenreService.DeleteMovieGenreAsync(id);

            return result == false ? NotFound() : NoContent();
        }
    }
}
