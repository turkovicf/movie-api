using AutoMapper;
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
        private readonly IMapper _mapper;
        public MovieActorService(IMovieActorRepository movieActorRepository, IMapper mapper)
        {
            _movieActorRepository = movieActorRepository;
            _mapper = mapper;
        }

        public async Task<MovieActorReadDto> AddMovieActorAsync(MovieActorCreateDto movieActorDto)
        {
            var movieActor = _mapper.Map<MovieActor>(movieActorDto);
            var addedMovieActor = await _movieActorRepository.AddMovieActorAsync(movieActor);

            return _mapper.Map<MovieActorReadDto>(addedMovieActor);
        }

        public async Task<bool> DeleteMovieActorAsync(Guid id)
        {
            return await _movieActorRepository.DeleteMovieActorAsync(id);
        }

        public async Task<MovieActorReadDetailsDto?> GetMovieActorByIdAsync(Guid id)
        {
            var movieActor = await _movieActorRepository.GetMovieActorByIdAsync(id);

            return _mapper.Map<MovieActorReadDetailsDto?>(movieActor);
        }

        public async Task<List<MovieActorReadDto>> GetMovieActorsAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? actorId = null)
        {
            var movieActors = await _movieActorRepository.GetMovieActorsAsync(pageNumber, pageSize, movieId, actorId);

            return movieActors.ConvertAll(ma => _mapper.Map<MovieActorReadDto>(ma)); 
        }

        public async Task<MovieActorReadDto?> UpdateMovieActorAsync(Guid id, MovieActorUpdateDto movieActorDto)
        {
            var movieActor = _mapper.Map<MovieActor>(movieActorDto);
            movieActor.Id = id;

            var updatedMovieActor = await _movieActorRepository.UpdateMovieActorAsync(movieActor);

            return _mapper.Map<MovieActorReadDto?>(updatedMovieActor);
        }
    }
}
