using AutoMapper;
using Movie.Application.Dtos.Director;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<DirectorReadDto> AddDirectorAsync(DirectorCreateDto directorDto)
        {
            var director = _mapper.Map<Director>(directorDto);
            
            var addedDirector = await _directorRepository.AddDirectorAsync(director);

            return _mapper.Map<DirectorReadDto>(addedDirector);
        }

        public async Task<bool> DeleteDirectorAsync(Guid id)
        {
            return await _directorRepository.DeleteDirectorAsync(id);
        }

        public async Task<DirectorReadDto?> GetDirectorByIdAsync(Guid id)
        {
            var director = await _directorRepository.GetDirectorByIdAsync(id);
            
            return _mapper.Map<DirectorReadDto?>(director);
        }

        public async Task<List<DirectorReadDto>> GetDirectorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            var directors = await _directorRepository.GetDirectorsAsync(pageNumber, pageSize, name, movie);

            return directors.ConvertAll(d => _mapper.Map<Director, DirectorReadDto>(d));
        }

        public async Task<DirectorReadDto?> UpdateDirectorAsync(Guid id, DirectorUpdateDto directorDto)
        {
            var director = _mapper.Map<Director>(directorDto);
            director.Id = id;

            var updatedDirector = await _directorRepository.UpdateDirectorAsync(director);

            return _mapper.Map<DirectorReadDto?>(updatedDirector);
        }
    }
}
