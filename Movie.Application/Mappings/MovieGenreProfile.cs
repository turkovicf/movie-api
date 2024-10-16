using AutoMapper;
using Movie.Application.Dtos.Genre;
using Movie.Application.Dtos.MovieGenre;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public class MovieGenreProfile : Profile
    {
        public MovieGenreProfile()
        {
            CreateMap<MovieGenreCreateDto, MovieGenre>();
            CreateMap<MovieGenre, MovieGenreReadDto>()
                .ForMember(dest => dest.MovieTitle,
                opt => opt.MapFrom(src => src.Movie != null ? src.Movie.Title : string.Empty))
                .ForMember(dest => dest.GenreName,
                opt => opt.MapFrom(src => src.Genre != null ? src.Genre.Name : string.Empty));
            CreateMap<MovieGenre, MovieGenreReadDetailsDto>()
                .ForMember(dest => dest.Movie,
                opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => src.Genre));
            CreateMap<MovieGenreUpdateDto, MovieGenre>();
            CreateMap<MovieGenre, GenreReadDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
