using AutoMapper;
using Movie.Application.Dtos.Actor;
using Movie.Domain.Entities;


namespace Movie.Application.Mappings
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorReadDto>();
            CreateMap<ActorReadDto, Actor>();
            CreateMap<ActorCreateDto, Actor>();
            CreateMap<ActorUpdateDto, Actor>();
        }
    }
}
