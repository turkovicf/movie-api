using AutoMapper;
using Movie.Application.Dtos.MovieGenre;
using Movie.Application.Interfaces;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;

namespace Movie.Application.Services
{
    public class MovieGenreService : IMovieGenreService
    {
        private readonly IMovieGenreRepository _movieGenreRepository;
        private readonly IMapper _mapper;
        public MovieGenreService(IMovieGenreRepository movieGenreRepository, IMapper mapper)
        {
            _movieGenreRepository = movieGenreRepository;
            _mapper = mapper;
        }

        public async Task<MovieGenreReadDto> AddMovieGenreAsync(MovieGenreCreateDto movieGenreDto)
        {
            var movieGenre = _mapper.Map<MovieGenre>(movieGenreDto);

            var addedMovieGenre = await _movieGenreRepository.AddMovieGenreAsync(movieGenre);

            return _mapper.Map<MovieGenreReadDto>(addedMovieGenre);
        }

        public async Task<bool> DeleteMovieGenreAsync(Guid id)
        {
            return await _movieGenreRepository.DeleteMovieGenreAsync(id);
        }

        public async Task<MovieGenreReadDetailsDto?> GetMovieGenreByIdAsync(Guid id)
        {
            var movieGenre = await _movieGenreRepository.GetMovieGenreByIdAsync(id);
            return _mapper.Map<MovieGenreReadDetailsDto>(movieGenre);
        }

        public async Task<List<MovieGenreReadDto>> GetMovieGenresAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? genreId = null)
        {
            var movieGenres = await _movieGenreRepository.GetMovieGenresAsync(pageNumber, pageSize, movieId, genreId);

            return movieGenres.ConvertAll(mg => _mapper.Map<MovieGenreReadDto>(mg));
        }

        public async Task<MovieGenreReadDto?> UpdateMovieGenreAsync(Guid id, MovieGenreUpdateDto movieGenreDto)
        {
            var movieGenre = _mapper.Map<MovieGenre>(movieGenreDto);
            movieGenre.Id = id;

            var updatedMovieGenre = await _movieGenreRepository.UpdateMovieGenreAsync(movieGenre);

            return _mapper.Map<MovieGenreReadDto?>(updatedMovieGenre);
        }
    }
}
