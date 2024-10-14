using Microsoft.Extensions.DependencyInjection;
using Movie.Application.Interfaces;
using Movie.Application.Services;

namespace Movie.Application.Configuration
{
    public static class Application
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IDirectorService, DirectorService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieActorService, MovieActorService>();

            return services;
        }
    }
}
