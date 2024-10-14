using Movie.Application.Dtos.Movie;

namespace Movie.Application.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieReadDto>> GetMoviesAsync(int pageNumber, int pageSize, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null);
        Task<MovieReadDetailsDto?> GetMovieByIdAsync(Guid id);
        Task<MovieReadDetailsDto> AddMovieAsync(MovieCreateDto movieDto);
        Task<MovieReadDetailsDto> UpdateMovieAsync(Guid id, MovieUpdateDto movieDto);
        Task<bool> DeleteMovieAsync(Guid id);
    }
}
