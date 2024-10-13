using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos.Director;
using Movie.Application.Interfaces;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DirectorReadDto>>> GetDirectors(int pageNumber = 1, int pageSize = 10, string? name = null, string? movie = null)
        {
            var directors = await _directorService.GetDirectorsAsync(pageNumber, pageSize, name, movie);
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorReadDto?>> GetDirectorById(Guid id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<DirectorReadDto>> AddDirector(DirectorCreateDto directorDto)
        {
            var director = await _directorService.AddDirectorAsync(directorDto);
            return CreatedAtAction(nameof(GetDirectorById), new { id = director.Id }, director);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DirectorReadDto>> UpdateDirector(Guid id, DirectorUpdateDto directorDto)
        {
            var updatedDirector = await _directorService.UpdateDirectorAsync(id, directorDto);
            return Ok(updatedDirector);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDirector(Guid id)
        {
            var result = await _directorService.DeleteDirectorAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
