using Movie.Application.Dtos.Actor;
using Movie.Application.Dtos.Genre;
using Movie.Application.Dtos.Movie;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieReadDetailsDto> AddMovieAsync(MovieCreateDto movieDto)
        {
            var movie = new Domain.Entities.Movie
            {
                Title = movieDto.Title,
                ReleaseYear = movieDto.ReleaseYear,
                Duration = movieDto.Duration,
                Description = movieDto.Description,
                PosterUrl = movieDto.PosterUrl,
                Rating = movieDto.Rating,
                DirectorId = movieDto.DirectorId,
                Language = movieDto.Language,
            };

            var addedMovie = await _movieRepository.AddMovieAsync(movie);

            addedMovie.MovieGenres = movieDto.GenreIds.Select(genreId => new MovieGenre { MovieId = addedMovie.Id, GenreId = genreId }).ToList();
            addedMovie.MovieActors = movieDto.ActorIds.Select(actorId => new MovieActor { MovieId = addedMovie.Id, ActorId = actorId }).ToList();

            await _movieRepository.UpdateMovieAsync(addedMovie);
            var updatedMovie = await _movieRepository.GetMovieByIdAsync(addedMovie.Id);

            return new MovieReadDetailsDto
            {
                Id = updatedMovie.Id,
                Title = updatedMovie.Title,
                ReleaseYear = updatedMovie.ReleaseYear,
                Duration = updatedMovie.Duration,
                Description = updatedMovie.Description,
                PosterUrl = updatedMovie.PosterUrl,
                Rating = (float)updatedMovie.Rating,
                DirectorId = updatedMovie.DirectorId,
                Language = updatedMovie.Language,
                Genres = updatedMovie.MovieGenres.Select(mg => new GenreReadDto { Id = mg.Id, Name = mg.Genre.Name }).ToList(),
                Actors = updatedMovie.MovieActors.Select(ma => new ActorReadDto { Id = ma.Id, Name = ma.Actor.Name, BirthDate = ma.Actor.BirthDate }).ToList()
            };
        }

        public Task<bool> DeleteMovieAsync(Guid id)
        {
            return _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<MovieReadDetailsDto?> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            return movie == null ? null : new MovieReadDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Duration = movie.Duration,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl,
                Rating = (float)movie.Rating,
                DirectorId = movie.DirectorId,
                Language = movie.Language,
                Genres = movie.MovieGenres.Select(mg => new GenreReadDto { Id = mg.Id, Name = mg.Genre.Name }).ToList(),
                Actors = movie.MovieActors.Select(ma => new ActorReadDto { Id = ma.Id, Name = ma.Actor.Name, BirthDate = ma.Actor.BirthDate }).ToList()
            };
        }

        public async Task<List<MovieReadDto>> GetMoviesAsync(int pageNumber, int pageSize, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null)
        {
            var movies = await _movieRepository.GetMoviesAsync(pageNumber, pageSize, name, genre, director, actor, releaseYear);

            return movies.ConvertAll(movie => new MovieReadDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Duration = movie.Duration,
                Description = movie.Description,
                PosterUrl = movie.PosterUrl,
                Rating = (float)movie.Rating,
                DirectorId = movie.DirectorId,
                Language = movie.Language,
            });
        }

        public async Task<MovieReadDetailsDto> UpdateMovieAsync(Guid id, MovieUpdateDto movieDto)
        {
            var movie = new Domain.Entities.Movie {
                Id = id,
                Title = movieDto.Title,
                ReleaseYear = movieDto.ReleaseYear,
                Duration = movieDto.Duration,
                Description = movieDto.Description,
                PosterUrl = movieDto.PosterUrl,
                Rating = movieDto.Rating,
                DirectorId = movieDto.DirectorId,
                Language = movieDto.Language,
                MovieGenres = movieDto.GenreIds.Select(genreId => new MovieGenre { MovieId = id, GenreId = genreId }).ToList(),
                MovieActors = movieDto.GenreIds.Select(actorId => new MovieActor { MovieId = id, ActorId = actorId }).ToList()
            };

            var updatedMovie = await _movieRepository.UpdateMovieAsync(movie);

            if (updatedMovie == null)
            {
                return null;
            }

            return new MovieReadDetailsDto
            {
                Id = updatedMovie.Id,
                Title = updatedMovie.Title,
                ReleaseYear = updatedMovie.ReleaseYear,
                Duration = updatedMovie.Duration,
                Description = updatedMovie.Description,
                PosterUrl = updatedMovie.PosterUrl,
                Rating = (float)updatedMovie.Rating,
                DirectorId = updatedMovie.DirectorId,
                Language = updatedMovie.Language,
                Genres = updatedMovie.MovieGenres.Select(mg => new GenreReadDto { Id = mg.Id, Name = mg.Genre.Name }).ToList(),
                Actors = updatedMovie.MovieActors.Select(ma => new ActorReadDto { Id = ma.Id, Name = ma.Actor.Name, BirthDate = ma.Actor.BirthDate }).ToList()
            };
        }
    }
}
