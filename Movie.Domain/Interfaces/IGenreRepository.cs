using Movie.Domain.Entities;

namespace Movie.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetGenresAsync(int pageNumber, int pageSize, string? name = null);
        Task<Genre?> GetGenreByIdAsync(Guid id);
        Task<Genre> AddGenreAsync(Genre genre);
        Task<Genre> UpdateGenreAsync(Genre genre);
        Task<bool> DeleteGenreAsync(Guid id);
    }
}
