using Movie.Application.Dtos.MovieActor;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IMovieActorService
    {
        Task<List<MovieActorReadDto>> GetMovieActorsAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? actorId = null);
        Task<MovieActorReadDetailsDto?> GetMovieActorByIdAsync(Guid id);
        Task<MovieActorReadDto> AddMovieActorAsync(MovieActorCreateDto movieActorDto);
        Task<MovieActorReadDto?> UpdateMovieActorAsync(Guid id, MovieActorUpdateDto movieActorDto);
        Task<bool> DeleteMovieActorAsync(Guid id);
    }
}
