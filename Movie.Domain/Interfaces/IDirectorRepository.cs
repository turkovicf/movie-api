using Movie.Domain.Entities;

namespace Movie.Domain.Interfaces
{
    public interface IDirectorRepository
    {
        Task<List<Director>> GetDirectorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null);
        Task<Director?> GetDirectorByIdAsync(Guid id);
        Task<Director> AddDirectorAsync(Director director);
        Task<Director> UpdateDirectorAsync(Director director);
        Task<bool> DeleteDirectorAsync(Guid id);
    }
}
