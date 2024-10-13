using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movie.Infrastructure.Data;
using Movie.Infrastructure.Repositories;
using Movie.Domain.Interfaces;

namespace Movie.Infrastructure.Configuration
{
    public static class Infrastrucute
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IDirectorRepository, DirectorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieActorRepository, MovieActorRepository>();
            services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
