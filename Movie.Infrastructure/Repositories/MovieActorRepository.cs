﻿using Movie.Domain.Entities;
using Movie.Domain.Interfaces;
using Movie.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Movie.Infrastructure.Repositories
{
    public class MovieActorRepository : IMovieActorRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public MovieActorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MovieActor> AddMovieActorAsync(MovieActor movieActor)
        {
            _appDbContext.MovieActors.Add(movieActor);
            await _appDbContext.SaveChangesAsync();
            
            var addedMovieActor = await _appDbContext.MovieActors.Include(ma => ma.Movie).Include(ma => ma.Actor).Where(ma => ma.Id == movieActor.Id).FirstOrDefaultAsync();
            return addedMovieActor;
        }

        public async Task<bool> DeleteMovieActorAsync(Guid id)
        {
            var movieActor = await _appDbContext.MovieActors.FindAsync(id);
            if (movieActor == null) return false;

            _appDbContext.MovieActors.Remove(movieActor);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<MovieActor?> GetMovieActorByIdAsync(Guid id)
        {
            return await _appDbContext.MovieActors.Include(ma => ma.Movie).Include(ma => ma.Actor).Where(ma => ma.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<MovieActor>> GetMovieActorsAsync(int pageNumber, int pageSize, Guid? movieId = null, Guid? actorId = null)
        {
            IQueryable<MovieActor> query = _appDbContext.MovieActors.Include(ma => ma.Movie).Include(ma => ma.Actor);

            if (movieId.HasValue)
            {
                query = query.Where(ma => ma.MovieId == movieId.Value);
            }

            if (actorId.HasValue)
            {
                query = query.Where(ma => ma.ActorId == actorId.Value);
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }

        public async Task<MovieActor?> UpdateMovieActorAsync(MovieActor movieActor)
        {
            _appDbContext.MovieActors.Update(movieActor);
            await _appDbContext.SaveChangesAsync();

            var updatedMovieActor = await _appDbContext.MovieActors.Include(ma => ma.Movie).Include(ma => ma.Actor).Where(ma => ma.Id == movieActor.Id).FirstOrDefaultAsync();
            return updatedMovieActor;
        }
    }
}
