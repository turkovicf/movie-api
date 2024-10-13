using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;

namespace Movie.Infrastructure.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public DirectorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Director> AddDirectorAsync(Director director)
        {
            _appDbContext.Directors.Add(director);
            await _appDbContext.SaveChangesAsync();
            return director;
        }

        public async Task<bool> DeleteDirectorAsync(Guid id)
        {
            var director = await _appDbContext.Directors.FindAsync(id);
            if (director == null) return false;

            _appDbContext.Directors.Remove(director);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Director>> GetDirectorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            IQueryable<Director> query = _appDbContext.Directors;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(d => d.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(movie))
            {
                query = query.Include(d => d.Movies).Where(d => d.Movies.Any(m => m.Title.Contains(movie)));
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Director?> GetDirectorByIdAsync(Guid id)
        {
            return await _appDbContext.Directors.FindAsync(id);
        }

        public async Task<Director> UpdateDirectorAsync(Director director)
        {
            _appDbContext.Directors.Update(director);
            await _appDbContext.SaveChangesAsync();
            return director;
        }
    }
}
