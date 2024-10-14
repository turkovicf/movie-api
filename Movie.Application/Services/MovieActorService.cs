using Movie.Application.Dtos.Actor;
using Movie.Application.Dtos.Movie;
using Movie.Application.Dtos.MovieActor;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class MovieActorService : IMovieActorService
    {
        private readonly IMovieActorRepository _movieActorRepository;
        public MovieActorService(IMovieActorRepository movieActorRepository)
        {
            _movieActorRepository = movieActorRepository;
        }

        public async Task<MovieActorReadDto> AddMovieActorAsync(MovieActorCreateDto movieActorDto)
        {
            var movieActor = new MovieActor { ActorId = movieActorDto.ActorId, MovieId = movieActorDto.MovieId };
            var addedMovieActor = await _movieActorRepository.AddMovieActorAsync(movieActor);

            return new MovieActorReadDto
            {
                Id = addedMovieActor.Id,
                ActorId = addedMovieActor.ActorId,
                ActorName = addedMovieActor.Actor.Name,
                MovieId = addedMovieActor.MovieId,
                MovieTitle = addedMovieActor.Movie.Title
            };
        }

        public async Task<bool> DeleteMovieActorAsync(Guid id)
        {
            return await _movieActorRepository.DeleteMovieActorAsync(id);
        }

        public async Task<MovieActorReadDetailsDto?> GetMovieActorByIdAsync(Guid id)
        {
            var movieActor = await _movieActorRepository.GetMovieActorByIdAsync(id);

            if (movieActor == null)
            {
                return null;
            }

            return new MovieActorReadDetailsDto
            {
                Id = id,
                Movie = new MovieReadDto 
                { 
                    Id = movieActor.Movie.Id, 
                    Title = movieActor.Movie.Title, 
                    Description = movieActor.Movie.Description, 
                    DirectorId = movieActor.Movie.DirectorId, 
                    Duration = movieActor.Movie.Duration,
                    Language = movieActor.Movie.Language,
                    PosterUrl = movieActor.Movie.PosterUrl,
                    Rating = (float)movieActor.Movie.Rating,
                    ReleaseYear = movieActor.Movie.ReleaseYear,
                },
                Actor = new ActorReadDto
                {
                    Id = movieActor.Actor.Id,
                    Name = movieActor.Actor.Name,
                    BirthDate = movieActor.Actor.BirthDate,
                }
            };
        }

        public async Task<List<MovieActorReadDto>> GetMovieActorsAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? actorId = null)
        {
            var movieActors = await _movieActorRepository.GetMovieActorsAsync(pageNumber, pageSize, movieId, actorId);

            if (movieActors == null)
            {
                return null;
            }

            return movieActors.ConvertAll(ma => new MovieActorReadDto
            {
                Id = ma.Id,
                ActorId = ma.ActorId,
                ActorName = ma.Actor.Name,
                MovieId = ma.MovieId,
                MovieTitle = ma.Movie.Title
            }); 
        }

        public async Task<MovieActorReadDto?> UpdateMovieActorAsync(Guid id, MovieActorUpdateDto movieActorDto)
        {
            var movieActor = new MovieActor
            {
                Id = id,
                MovieId = movieActorDto.MovieId,
                ActorId = movieActorDto.ActorId
            };

            var updatedMovieActor = await _movieActorRepository.UpdateMovieActorAsync(movieActor);

            if (updatedMovieActor == null)
            {
                return null;
            }

            return new MovieActorReadDto
            {
                Id = id,
                MovieId = updatedMovieActor.MovieId,
                MovieTitle = updatedMovieActor.Movie.Title,
                ActorId = updatedMovieActor.ActorId,
                ActorName = updatedMovieActor.Actor.Name
            };
        }
    }
}
