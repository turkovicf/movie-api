using Microsoft.EntityFrameworkCore;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;

namespace Movie.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public MovieRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Domain.Entities.Movie?> GetMovieByIdAsync(Guid id)
        {
            return await _appDbContext.Movies.Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor).FirstOrDefaultAsync();
        }

        public async Task<List<Domain.Entities.Movie>> GetMoviesAsync(int pageNumber, int pageSize, string? name = null, string? genre = null, string? director = null, string? actor = null, int? releaseYear = null)
        {
            IQueryable<Domain.Entities.Movie> query = _appDbContext.Movies.Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre).Include(m => m.MovieActors).ThenInclude(ma => ma.Actor);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Title.Contains(name));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(m => m.MovieGenres.Any(mg => mg.Genre.Name.Contains(genre)));
            }

            if (!string.IsNullOrEmpty(director))
            {
                query = query.Where(m => m.DirectorId == _appDbContext.Directors.FirstOrDefault(d => d.Name.Contains(director)).Id);
            }

            if (!string.IsNullOrEmpty(actor))
            {
                query = query.Where(m => m.MovieActors.Any(ma => ma.Actor.Name.Contains(actor)));
            }

            if (releaseYear.HasValue)
            {
                query = query.Where(m => m.ReleaseYear.Equals(releaseYear));
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        
        public async Task<Domain.Entities.Movie> AddMovieAsync(Domain.Entities.Movie movie)
        {
            await _appDbContext.Movies.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var movie = await _appDbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return false; 
            }

            _appDbContext.Movies.Remove(movie);
            await _appDbContext.SaveChangesAsync(); 
            return true;
        }

        public async Task<Domain.Entities.Movie> UpdateMovieAsync(Domain.Entities.Movie movie)
        {
            var existingMovie = await _appDbContext.Movies
                .Include(m => m.MovieGenres)
                .Include(m => m.MovieActors)
                .FirstOrDefaultAsync(m => m.Id == movie.Id);

            if (existingMovie == null)
            {
                throw new KeyNotFoundException("Movie not found."); 
            }

            existingMovie.Title = movie.Title;
            existingMovie.ReleaseYear = movie.ReleaseYear;
            existingMovie.Duration = movie.Duration;
            existingMovie.Description = movie.Description;
            existingMovie.PosterUrl = movie.PosterUrl;
            existingMovie.Rating = movie.Rating;
            existingMovie.DirectorId = movie.DirectorId;
            existingMovie.Language = movie.Language;
            existingMovie.MovieGenres = movie.MovieGenres;
            existingMovie.MovieActors = movie.MovieActors;

            await _appDbContext.SaveChangesAsync(); 
            return existingMovie;
        }
    }
}
