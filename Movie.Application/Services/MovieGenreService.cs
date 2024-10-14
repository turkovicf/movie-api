using Movie.Application.Dtos.MovieGenre;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class MovieGenreService : IMovieGenreService
    {
        private readonly IMovieGenreRepository _movieGenreRepository;
        public MovieGenreService(IMovieGenreRepository movieGenreRepository)
        {
            _movieGenreRepository = movieGenreRepository;
        }

        public async Task<MovieGenreReadDto> AddMovieGenreAsync(MovieGenreCreateDto movieGenreDto)
        {
            var movieGenre = new MovieGenre { GenreId = movieGenreDto.GenreId, MovieId = movieGenreDto.MovieId };

            var addedMovieGenre = await _movieGenreRepository.AddMovieGenreAsync(movieGenre);

            return new MovieGenreReadDto
            {
                Id = addedMovieGenre.Id,
                MovieId = addedMovieGenre.MovieId,
                MovieTitle = addedMovieGenre.Movie.Title,
                GenreId = addedMovieGenre.GenreId,
                GenreName = addedMovieGenre.Genre.Name,
            };
        }

        public async Task<bool> DeleteMovieGenreAsync(Guid id)
        {
            return await _movieGenreRepository.DeleteMovieGenreAsync(id);
        }

        public Task<MovieGenreReadDetailsDto?> GetMovieGenreByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieGenreReadDto>> GetMovieGenresAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? genreId = null)
        {
            var movieGenres = await _movieGenreRepository.GetMovieGenresAsync(pageNumber, pageSize, movieId, genreId);

            return movieGenres.ConvertAll(mg => new MovieGenreReadDto
            {
                Id = mg.Id,
                MovieId = mg.MovieId,
                MovieTitle = mg.Movie.Title,
                GenreId = mg.GenreId,
                GenreName = mg.Genre.Name
            });
        }

        public async Task<MovieGenreReadDto?> UpdateMovieGenreAsync(Guid id, MovieGenreUpdateDto movieGenreDto)
        {
            var movieGenre = new MovieGenre { Id = id, MovieId = movieGenreDto.MovieId, GenreId = movieGenreDto.GenreId };

            var updatedMovieGenre = await _movieGenreRepository.UpdateMovieGenreAsync(movieGenre);

            if (updatedMovieGenre == null) 
            {
                return null;
            }

            return new MovieGenreReadDto
            {
                Id = id,
                MovieId = updatedMovieGenre.MovieId,
                MovieTitle = updatedMovieGenre.Movie.Title,
                GenreId = updatedMovieGenre.GenreId,
                GenreName = updatedMovieGenre.Genre.Name
            };
        }
    }
}
