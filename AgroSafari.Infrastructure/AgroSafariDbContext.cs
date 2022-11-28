using AgroSafari.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AgroSafari.Infrastructure
{
    public class AgroSafariDbContext : DbContext
    {
        public AgroSafariDbContext(DbContextOptions<AgroSafariDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // 1° Migration utilizada: dotnet ef migrations add InitialMigration -s ../AgroSafariAPI/AgroSafari.API.csproj -o ./Persistence/Migrations
        // Update: dotnet ef database update -s ../AgroSafariAPI/AgroSafari.API.csproj
    }
}