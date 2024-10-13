using Movie.Application.Dtos.Director;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<DirectorReadDto> AddDirectorAsync(DirectorCreateDto directorDto)
        {
            var director = new Director
            {
                Name = directorDto.Name,
                BirthDate = directorDto.BirthDate
            };
            var addedDirector = await _directorRepository.AddDirectorAsync(director);

            return new DirectorReadDto { Id = addedDirector.Id, Name = addedDirector.Name, BirthDate = addedDirector.BirthDate };
        }

        public async Task<bool> DeleteDirectorAsync(Guid id)
        {
            return await _directorRepository.DeleteDirectorAsync(id);
        }

        public async Task<DirectorReadDto?> GetDirectorByIdAsync(Guid id)
        {
            var director = await _directorRepository.GetDirectorByIdAsync(id);

            if (director == null)
            {
                return null;
            }

            return new DirectorReadDto { Id = director.Id, Name = director.Name, BirthDate = director.BirthDate };
        }

        public async Task<List<DirectorReadDto>> GetDirectorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            var directors = await _directorRepository.GetDirectorsAsync(pageNumber, pageSize, name, movie);

            return directors.ConvertAll(d => new DirectorReadDto { Id = d.Id, Name = d.Name, BirthDate = d.BirthDate });
        }

        public async Task<DirectorReadDto> UpdateDirectorAsync(Guid id, DirectorUpdateDto directorDto)
        {
            var director = new Director { Id = id, Name = directorDto.Name, BirthDate = directorDto.BirthDate };
            var updatedDirector = await _directorRepository.UpdateDirectorAsync(director);

            return new DirectorReadDto { Id = updatedDirector.Id, Name = updatedDirector.Name, BirthDate = updatedDirector.BirthDate };
        }
    }
}
