using Movie.Application.Configuration;
using Movie.Infrastructure.Configuration;

namespace Movie.Api.Configuration
{
    public static class Api
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI().AddInfrastructureDI(configuration);


            return services;
        }
    }
}
