using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Movie.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public GenreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            _appDbContext.Genres.Add(genre);
            await _appDbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<bool> DeleteGenreAsync(Guid id)
        {
            var genre = await _appDbContext.Genres.FindAsync(id);
            if (genre == null) return false;

            _appDbContext.Genres.Remove(genre);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Genre?> GetGenreByIdAsync(Guid id)
        {
            return await _appDbContext.Genres.FindAsync(id);
        }

        public async Task<List<Genre>> GetGenresAsync(int pageNumber, int pageSize, string? name = null)
        {
            IQueryable<Genre> query = _appDbContext.Genres;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(g => g.Name.Contains(name));
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Genre> UpdateGenreAsync(Genre genre)
        {
            _appDbContext.Genres.Update(genre);
            await _appDbContext.SaveChangesAsync();
            return genre;
        }
    }
}
