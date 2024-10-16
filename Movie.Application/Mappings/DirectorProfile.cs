using AutoMapper;
using Movie.Application.Dtos.Director;
using Movie.Domain.Entities;

namespace Movie.Application.Mappings
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile() 
        {
            CreateMap<DirectorCreateDto, Director>();
            CreateMap<Director, DirectorReadDto>();
            CreateMap<DirectorUpdateDto, Director>();
        }
    }
}
