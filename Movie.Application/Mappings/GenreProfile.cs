using AutoMapper;
using Movie.Application.Dtos.Genre;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile() 
        {
            CreateMap<Genre, GenreReadDto>();
            CreateMap<GenreCreateDto, Genre>();
            CreateMap<GenreUpdateDto, Genre>();
        }
    }
}
