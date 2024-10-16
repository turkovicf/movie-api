using AutoMapper;
using Movie.Application.Dtos.Movie;

namespace Movie.Application.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile() 
        {
            CreateMap<MovieCreateDto, Domain.Entities.Movie>();
            CreateMap<Domain.Entities.Movie, MovieReadDetailsDto>()
                .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.MovieGenres))
                .ForMember(dest => dest.Actors,
                opt => opt.MapFrom(src => src.MovieActors));
            CreateMap<Domain.Entities.Movie, MovieReadDto>();
            CreateMap<MovieUpdateDto, Domain.Entities.Movie>(); 
        }
    }
}
