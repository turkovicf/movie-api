using Movie.Application.Dtos.Director;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IDirectorService
    {
        Task<DirectorReadDto> AddDirectorAsync(DirectorCreateDto directorDto);
        Task<bool> DeleteDirectorAsync(Guid id);
        Task<DirectorReadDto?> GetDirectorByIdAsync(Guid id);
        Task<List<DirectorReadDto>> GetDirectorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null);
        Task<DirectorReadDto> UpdateDirectorAsync(Guid id, DirectorUpdateDto directorDto);
    }
}
