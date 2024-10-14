using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos.Actor;
using Movie.Application.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorReadDto>>> GetActors(int pageNumber = 1, int pageSize = 10, string? name = null, string? movie = null)
        {
            var actors = await _actorService.GetActorsAsync(pageNumber, pageSize, name, movie);
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorReadDto>> GetActorById(Guid id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);

            return actor == null ? NotFound() : Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<ActorReadDto>> AddActor(ActorCreateDto actorDto)
        {
            var createdActor = await _actorService.AddActorAsync(actorDto);
            return CreatedAtAction(nameof(GetActorById), new { id = createdActor.Id }, createdActor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActorReadDto>> UpdateActor(Guid id, ActorUpdateDto actorDto)
        {
            var updatedActor = await _actorService.UpdateActorAsync(id, actorDto);

            return updatedActor == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteActor(Guid id)
        {
            var result = await _actorService.DeleteActorAsync(id);

            return result == false ? NotFound() : NoContent();
        }

    }
}
