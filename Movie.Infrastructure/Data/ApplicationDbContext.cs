using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;

namespace Movie.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Movie.Domain.Entities.Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
