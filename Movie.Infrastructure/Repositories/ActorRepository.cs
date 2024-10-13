using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;

namespace Movie.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public ActorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Actor?> GetActorByIdAsync(Guid id)
        {
            return await _appDbContext.Actors.FindAsync(id);
        }
        public async Task<List<Actor>> GetActorsAsync(int pageNumber, int pageSize, string? name = null, string? movie = null)
        {
            IQueryable<Actor> query = _appDbContext.Actors;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.Name == name);
            }

            if (!string.IsNullOrEmpty(movie))
            {
                query = query.Include(a => a.MovieActors).ThenInclude(ma => ma.Movie.Title.Contains(movie));
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
        public async Task<Actor> AddActorAsync(Actor actor)
        {
            await _appDbContext.Actors.AddAsync(actor);
            await _appDbContext.SaveChangesAsync();
            return actor;
        }

        public async Task<bool> DeleteActorAsync(Guid id)
        {
            var actor = await _appDbContext.Actors.FindAsync(id);
            if (actor == null)
            {
                return false;
            }

            _appDbContext.Actors.Remove(actor);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Actor> UpdateActorAsync(Actor actor)
        {
            var existingActor = await _appDbContext.Actors.FindAsync(actor.Id);
            if (existingActor == null)
            {
                return null;
            }

            existingActor.Name = actor.Name;
            existingActor.BirthDate = actor.BirthDate;

            await _appDbContext.SaveChangesAsync();
            return existingActor;
        }
    }
}
