using Movie.Application.Dtos.Genre;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movie.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<GenreReadDto> AddGenreAsync(GenreCreateDto genreDto)
        {
            var genre = new Genre { Name = genreDto.Name };
            var addedGenre = await _genreRepository.AddGenreAsync(genre);

            return new GenreReadDto { Id = addedGenre.Id, Name = addedGenre.Name };
        }

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            return await _genreRepository.DeleteGenreAsync(id);
        }

        public async Task<GenreReadDto?> GetGenreByIdAsync(Guid id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);
            if (genre == null) return null;

            return new GenreReadDto { Id = genre.Id, Name = genre.Name };
        }

        public async Task<List<GenreReadDto>> GetGenresAsync(int pageNumber, int pageSize, string? name = null)
        {
            var genres = await _genreRepository.GetGenresAsync(pageNumber, pageSize, name);

            return genres.ConvertAll(g => new GenreReadDto { Id = g.Id, Name = g.Name });
        }

        public async Task<GenreReadDto> UpdateGenreAsync(Guid id, GenreUpdateDto genreDto)
        {
            var genre = new Genre { Id = id, Name = genreDto.Name };
            var updatedGenre = await _genreRepository.UpdateGenreAsync(genre);

            return new GenreReadDto { Id = updatedGenre.Id, Name = updatedGenre.Name };
        }
    }
}
