using Movie.Application.Dtos.MovieGenre;
using Movie.Domain.Entities;

namespace Movie.Application.Interfaces
{
    public interface IMovieGenreService
    {
        Task<List<MovieGenreReadDto>> GetMovieGenresAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? genreId = null);
        Task<MovieGenreReadDetailsDto?> GetMovieGenreByIdAsync(Guid id);
        Task<MovieGenreReadDto> AddMovieGenreAsync(MovieGenreCreateDto movieGenreDto);
        Task<MovieGenreReadDto?> UpdateMovieGenreAsync(Guid id, MovieGenreUpdateDto movieGenreDto);
        Task<bool> DeleteMovieGenreAsync(Guid id);
    }
}
