using Movie.Domain.Entities;

namespace Movie.Domain.Interfaces
{
    public interface IMovieActorRepository
    {
        Task<List<MovieActor>> GetMovieActorsAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? actorId = null);
        Task<MovieActor?> GetMovieActorByIdAsync(Guid id);
        Task<MovieActor> AddMovieActorAsync(MovieActor movieActor);
        Task<bool> DeleteMovieActorAsync(Guid id);
    }
}
