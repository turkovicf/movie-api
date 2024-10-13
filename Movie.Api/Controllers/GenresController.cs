using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Dtos.Genre;
using Movie.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreReadDto>>> GetGenres(int pageNumber = 1, int pageSize = 10, string? name = null)
        {
            var genres = await _genreService.GetGenresAsync(pageNumber, pageSize, name);
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreReadDto>> GetGenreById(Guid id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<ActionResult<GenreReadDto>> AddGenre(GenreCreateDto genreCreateDto)
        {
            var createdGenre = await _genreService.AddGenreAsync(genreCreateDto);
            return CreatedAtAction(nameof(GetGenreById), new { id = createdGenre.Id }, createdGenre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GenreReadDto>> UpdateGenre(Guid id, GenreUpdateDto genreUpdateDto)
        {
            
            var updatedGenre = await _genreService.UpdateGenreAsync(id, genreUpdateDto);
            if (updatedGenre == null)
            {
                return NotFound();
            }
            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(Guid id)
        {
            var result = await _genreService.DeleteGenreAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
