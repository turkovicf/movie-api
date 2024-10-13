using Microsoft.Extensions.DependencyInjection;

namespace Movie.Domain.Configuration
{
    public static class Domain
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
