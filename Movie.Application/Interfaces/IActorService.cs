using Movie.Application.Dtos.Actor;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IActorService
    {
        Task<List<ActorReadDto>> GetActorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null);
        Task<ActorReadDto?> GetActorByIdAsync(Guid id);
        Task<ActorReadDto> AddActorAsync(ActorCreateDto actorDto);
        Task<ActorReadDto> UpdateActorAsync(Guid id, ActorUpdateDto actorDto);
        Task<bool> DeleteActorAsync(Guid id);
    }
}
