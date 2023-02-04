using Metflix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Metflix.Infraestructure.Persistence
{
    public class MetflixDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MetflixDbContext(DbContextOptions<MetflixDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
