using eBrew.Cloud.KeyManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBrew.Cloud.KeyManagement.Infrastructure.EntityTypeConfigurations;

public sealed class ApiKeyTypeConfiguration : IEntityTypeConfiguration<ApiKey>
{
    public void Configure(EntityTypeBuilder<ApiKey> builder)
    {
        builder.HasKey(ak => ak.Id);
            
        builder.Property(ak => ak.Description)
            .HasMaxLength(300);

        builder.HasIndex(ak => ak.SecretKey)
            .IsUnique();
    }
}