using Movie.Application.Dtos.Actor;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ActorReadDto> AddActorAsync(ActorCreateDto actorDto)
        {
            var actor = new Actor { Name = actorDto.Name, BirthDate = actorDto.BirthDate };
            var addedActor = await _actorRepository.AddActorAsync(actor);

            return new ActorReadDto { Id = addedActor.Id, Name = addedActor.Name, BirthDate = addedActor.BirthDate };
        }

        public async Task<bool> DeleteActorAsync(Guid id)
        {
            return await _actorRepository.DeleteActorAsync(id);
        }

        public async Task<ActorReadDto?> GetActorByIdAsync(Guid id)
        {
            var actor = await _actorRepository.GetActorByIdAsync(id);
            
            if (actor == null)
            {
                return null;
            }

            return new ActorReadDto { Id = actor.Id, Name= actor.Name, BirthDate = actor.BirthDate };
        }

        public async Task<List<ActorReadDto>> GetActorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            var actors = await _actorRepository.GetActorsAsync(pageNumber, pageSize, name, movie);

            return actors.ConvertAll(a => new ActorReadDto { Id =  a.Id, Name = a.Name, BirthDate = a.BirthDate });
        }

        public async Task<ActorReadDto> UpdateActorAsync(Guid id, ActorUpdateDto actorDto)
        {
            var actor = new Actor { Id = id, Name = actorDto.Name, BirthDate = actorDto.BirthDate };
            var updatedActor = await _actorRepository.UpdateActorAsync(actor);

            if (updatedActor == null)
            {
                return null;
            }

            return new ActorReadDto { Id = updatedActor.Id, BirthDate = updatedActor.BirthDate, Name = updatedActor.Name };
        }
    }
}
