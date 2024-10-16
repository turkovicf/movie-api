using AutoMapper;
using Movie.Application.Dtos.Genre;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreReadDto> AddGenreAsync(GenreCreateDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            var addedGenre = await _genreRepository.AddGenreAsync(genre);

            return _mapper.Map<GenreReadDto>(addedGenre);
        }

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            return await _genreRepository.DeleteGenreAsync(id);
        }

        public async Task<GenreReadDto?> GetGenreByIdAsync(Guid id)
        {
            var genre = await _genreRepository.GetGenreByIdAsync(id);

            return _mapper.Map<GenreReadDto?>(genre);
        }

        public async Task<List<GenreReadDto>> GetGenresAsync(int pageNumber, int pageSize, string? name = null)
        {
            var genres = await _genreRepository.GetGenresAsync(pageNumber, pageSize, name);

            return genres.ConvertAll(g => _mapper.Map<GenreReadDto>(g));
        }

        public async Task<GenreReadDto> UpdateGenreAsync(Guid id, GenreUpdateDto genreDto)
        {
            var genre = _mapper.Map<Genre>(genreDto);
            genre.Id = id;

            var updatedGenre = await _genreRepository.UpdateGenreAsync(genre);

            return _mapper.Map<GenreReadDto>(updatedGenre);
        }
    }
}
