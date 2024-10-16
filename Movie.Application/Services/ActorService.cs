using AutoMapper;
using Movie.Application.Dtos.Actor;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<ActorReadDto> AddActorAsync(ActorCreateDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            var addedActor = await _actorRepository.AddActorAsync(actor);

            return _mapper.Map<ActorReadDto>(addedActor);
        }

        public async Task<bool> DeleteActorAsync(Guid id)
        {
            return await _actorRepository.DeleteActorAsync(id);
        }

        public async Task<ActorReadDto?> GetActorByIdAsync(Guid id)
        {
            var actor = await _actorRepository.GetActorByIdAsync(id);

            return _mapper.Map<ActorReadDto?>(actor);
        }

        public async Task<List<ActorReadDto>> GetActorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            var actors = await _actorRepository.GetActorsAsync(pageNumber, pageSize, name, movie);

            return actors.ConvertAll(a => _mapper.Map<ActorReadDto>(a));
        }

        public async Task<ActorReadDto?> UpdateActorAsync(Guid id, ActorUpdateDto actorDto)
        {
            var actor = _mapper.Map<Actor>(actorDto);
            actor.Id = id;

            var updatedActor = await _actorRepository.UpdateActorAsync(actor);

            return _mapper.Map<ActorReadDto?>(updatedActor);
        }
    }
}
