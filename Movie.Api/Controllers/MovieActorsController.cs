using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos.MovieActor;
using Movie.Application.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly IMovieActorService _movieActorService;
        public MovieActorsController(IMovieActorService movieActorService)
        {
            _movieActorService = movieActorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieActorReadDto>>> GetMovieActors(int pageNumber = 1, int pageSize = 10, Guid? movieId = null, Guid? actorId = null)
        {
            var movieActors = await _movieActorService.GetMovieActorsAsync(pageNumber, pageSize, movieId, actorId);

            return Ok(movieActors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActorReadDetailsDto>> GetMovieActorById(Guid id)
        {
            var movieActor = await _movieActorService.GetMovieActorByIdAsync(id);

            return Ok(movieActor);
        }

        [HttpPost]
        public async Task<ActionResult<MovieActorReadDto>> AddMovieActor(MovieActorCreateDto movieActorDto)
        {
            var addedMovieActor = await _movieActorService.AddMovieActorAsync(movieActorDto);
            return CreatedAtAction(nameof(GetMovieActorById), new { id = addedMovieActor.Id }, addedMovieActor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovieActorReadDto>> UpdateMovieActor(Guid id, MovieActorUpdateDto movieActorDto)
        {
            var updatedMovieActor = await _movieActorService.UpdateMovieActorAsync(id, movieActorDto);
            
            return updatedMovieActor == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteMovieActor(Guid id)
        {
            var result = await _movieActorService.DeleteMovieActorAsync(id);

            return result == true ? NoContent() : NotFound();
        }


    }
}
