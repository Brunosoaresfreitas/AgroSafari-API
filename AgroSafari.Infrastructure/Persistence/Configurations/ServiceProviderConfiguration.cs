using AgroSafari.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSafari.Infrastructure.Persistence.Configurations
{
    public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
    {
        public void Configure(EntityTypeBuilder<ServiceProvider> builder)
        {
            // Setando a chave primária da tabela do banco de dados
            builder
                .HasKey(s => s.Id);
        }
    }
}
