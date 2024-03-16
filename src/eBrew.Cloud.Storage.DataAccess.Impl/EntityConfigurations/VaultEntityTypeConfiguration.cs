using eBrew.Cloud.Storage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBrew.Cloud.Storage.DataAccess.Impl.EntityConfigurations;

public sealed class VaultEntityTypeConfiguration : IEntityTypeConfiguration<Vault>
{
    public void Configure(EntityTypeBuilder<Vault> builder)
    {
        builder.HasKey(v => new { v.Name, v.UserId });
        
        builder.Property(v => v.Name)
            .HasMaxLength(100);
    }
}