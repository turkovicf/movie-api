namespace Movie.Domain.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Entities.Movie>> GetMoviesAsync(int pageNumber, int pageSize, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null);
        Task<Entities.Movie?> GetMovieByIdAsync(Guid id);
        Task<Entities.Movie> AddMovieAsync(Entities.Movie movie);
        Task<Entities.Movie> UpdateMovieAsync(Entities.Movie movie);
        Task<bool> DeleteMovieAsync(Guid id);
    }
}
