using Movie.Domain.Entities;

namespace Movie.Domain.Interfaces
{
    public interface IMovieGenreRepository
    {
        Task<List<MovieGenre>> GetMovieGenresAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? genreId = null);
        Task<MovieGenre?> GetMovieGenreByIdAsync(Guid id);
        Task<MovieGenre> AddMovieGenreAsync(MovieGenre movieGenre);
        Task<bool> DeleteMovieGenreAsync(Guid id);
    }
}
