using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Interfaces;
using Movie.Application.Mappings;
using Movie.Application.Services;

namespace Movie.Application.Configuration
{
    public static class Application
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ActorProfile));
            services.AddAutoMapper(typeof(DirectorProfile));
            services.AddAutoMapper(typeof(GenreProfile));
            services.AddAutoMapper(typeof(MovieActorProfile));
            services.AddAutoMapper(typeof(MovieGenreProfile));
            services.AddAutoMapper(typeof(Domain.Entities.Movie));

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieActorService, MovieActorService>();
            services.AddScoped<IMovieGenreService, MovieGenreService>();

            return services;
        }
    }
}
