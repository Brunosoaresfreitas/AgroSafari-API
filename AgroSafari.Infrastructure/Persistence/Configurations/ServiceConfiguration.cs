using AgroSafari.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSafari.Infrastructure.Persistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasOne(s => s.ServiceProvider)  // Meu serviço tem um provedor de serviço
                .WithMany(s => s.OwnedServices)  // Meu provedor de serviço pode ser dono de vários serviços
                .HasForeignKey(s => s.IdServiceProvider)  // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.Client)  // Meu serviço tem um cliente
                .WithMany(s => s.HiredServices)  // Meu cliente pode ter vários serviços contratados
                .HasForeignKey(s => s.IdClient)  // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
