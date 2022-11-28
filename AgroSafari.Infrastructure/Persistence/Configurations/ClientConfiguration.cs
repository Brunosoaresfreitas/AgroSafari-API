using AgroSafari.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgroSafari.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(c => c.Id);
        }
    }
}
