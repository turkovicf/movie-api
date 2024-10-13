using Movie.Domain.Entities;

namespace Movie.Domain.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetActorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null);
        Task<Actor?> GetActorByIdAsync(Guid id);
        Task<Actor> AddActorAsync(Actor actor);
        Task<Actor> UpdateActorAsync(Actor actor);
        Task<bool> DeleteActorAsync(Guid id);
    }
}
