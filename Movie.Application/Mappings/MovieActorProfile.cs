using AutoMapper;
using Movie.Application.Dtos.Actor;
using Movie.Application.Dtos.MovieActor;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public class MovieActorProfile : Profile
    {
        public MovieActorProfile()
        {
            CreateMap<MovieActorCreateDto, MovieActor>();
            CreateMap<MovieActor, MovieActorReadDto>()
                .ForMember(dest => dest.MovieTitle, 
                opt => opt.MapFrom(src => src.Movie != null ? src.Movie.Title : string.Empty))
                .ForMember(dest => dest.ActorName,
                opt => opt.MapFrom(src => src.Actor != null ? src.Actor.Name : string.Empty));
            CreateMap<MovieActor, MovieActorReadDetailsDto>()
                .ForMember(dest => dest.Movie, 
                opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Actor,
                opt => opt.MapFrom(src => src.Actor));
            CreateMap<MovieActorUpdateDto, MovieActor>();
            CreateMap<MovieActor, ActorReadDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Actor.Name))
                .ForMember(dest => dest.BirthDate,
                opt => opt.MapFrom(src => src.Actor.BirthDate));
        }
    }
}
