using Movie.Application.Dtos.Genre;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreReadDto>> GetGenresAsync(int pageNumber, int pageSize, string? name = null);
        Task<GenreReadDto?> GetGenreByIdAsync(Guid id);
        Task<GenreReadDto> AddGenreAsync(GenreCreateDto genreDto);
        Task<GenreReadDto> UpdateGenreAsync(Guid id, GenreUpdateDto genreDto);
        Task<bool> DeleteGenreAsync(Guid id);
    }
}
