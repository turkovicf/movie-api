using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Movie.Infrastructure.Repositories
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MovieGenreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MovieGenre> AddMovieGenreAsync(MovieGenre movieGenre)
        {
            _appDbContext.MoviesGenres.Add(movieGenre);
            await _appDbContext.SaveChangesAsync();
            return movieGenre;
        }

        public async Task<bool> DeleteMovieGenreAsync(Guid id)
        {
            var movieGenre = await _appDbContext.MoviesGenres.FindAsync(id);
            if (movieGenre == null) return false;

            _appDbContext.MoviesGenres.Remove(movieGenre);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<MovieGenre?> GetMovieGenreByIdAsync(Guid id)
        {
            return await _appDbContext.MoviesGenres.Include(mg => mg.Genre).Include(mg => mg.Movie).Where(mg => mg.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MovieGenre>> GetMovieGenresAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? genreId = null)
        {
            IQueryable<MovieGenre> query = _appDbContext.MoviesGenres.Include(mg => mg.Movie).Include(mg => mg.Genre);

            if (movieId.HasValue)
            {
                query = query.Where(mg => mg.MovieId == movieId.Value);
            }

            if (genreId.HasValue)
            {
                query = query.Where(mg => mg.GenreId == genreId.Value);
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }

        public async Task<MovieGenre?> UpdateMovieGenreAsync(MovieGenre movieGenre)
        {
            _appDbContext.MoviesGenres.Update(movieGenre);
            await _appDbContext.SaveChangesAsync();

            var updatedMovieGenre = await _appDbContext.MoviesGenres.Include(mg => mg.Movie).Include(mg => mg.Genre).Where(mg => mg.Id == movieGenre.Id).FirstOrDefaultAsync();
            return updatedMovieGenre;
        }
    }
}
