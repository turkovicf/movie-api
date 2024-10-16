using AutoMapper;
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
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper) 
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieReadDetailsDto> AddMovieAsync(MovieCreateDto movieDto)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(movieDto);

            var addedMovie = await _movieRepository.AddMovieAsync(movie);

            if (movieDto.GenreIds != null)
            {
                addedMovie.MovieGenres = movieDto.GenreIds.Select(genreId => new MovieGenre { MovieId = addedMovie.Id, GenreId = genreId }).ToList();
            }

            if (movieDto.ActorIds != null)
            {
                addedMovie.MovieActors = movieDto.ActorIds.Select(actorId => new MovieActor { MovieId = addedMovie.Id, ActorId = actorId }).ToList();
            }

            if (movieDto.ActorIds != null || movieDto.GenreIds != null)
            {
                await _movieRepository.UpdateMovieAsync(addedMovie);
            }

            var updatedMovie = await _movieRepository.GetMovieByIdAsync(addedMovie.Id);

            return _mapper.Map<MovieReadDetailsDto>(updatedMovie);
        }

        public Task<bool> DeleteMovieAsync(Guid id)
        {
            return _movieRepository.DeleteMovieAsync(id);
        }

        public async Task<MovieReadDetailsDto?> GetMovieByIdAsync(Guid id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);

            return _mapper.Map<MovieReadDetailsDto?>(movie);
        }

        public async Task<List<MovieReadDto>> GetMoviesAsync(int pageNumber, int pageSize, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null)
        {
            var movies = await _movieRepository.GetMoviesAsync(pageNumber, pageSize, name, genre, director, actor, releaseYear);

            return movies.ConvertAll(m => _mapper.Map<MovieReadDto>(m));
        }

        public async Task<MovieReadDetailsDto?> UpdateMovieAsync(Guid id, MovieUpdateDto movieDto)
        {
            var movie = _mapper.Map<Domain.Entities.Movie>(movieDto);

            movie.Id = id;

            if (movieDto.GenreIds != null || movieDto.GenreIds.Count() > 0)
            {
                movie.MovieGenres = movieDto.GenreIds.Select(genreId => new MovieGenre { MovieId = id, GenreId = genreId }).ToList();
            }

            if (movieDto.ActorIds != null || movieDto.ActorIds.Count() > 0)
            {
                movie.MovieActors = movieDto.ActorIds.Select(actorId => new MovieActor { MovieId = id, ActorId = actorId }).ToList();
            }

            var updatedMovie = await _movieRepository.UpdateMovieAsync(movie);

            return _mapper.Map<MovieReadDetailsDto?>(updatedMovie);
        }
    }
}
