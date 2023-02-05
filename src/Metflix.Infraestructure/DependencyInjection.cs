using Metflix.Infraestructure.Authentication;
using Metflix.Infraestructure.Authentication.Interfaces;
using Metflix.Infraestructure.Persistence;
using Metflix.Infraestructure.Persistence.Managers;
using Metflix.Infraestructure.Persistence.Repositories;
using Metflix.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metflix.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(
            this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("MetflixCS");

            services.AddDbContext<MetflixDbContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepositoryBase, RepositoryBase>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddSingleton<IJWTTokenGenerator, JWTTokenGenerator>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
