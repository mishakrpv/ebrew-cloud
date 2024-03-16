using eBrew.Cloud.Storage.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBrew.Cloud.Storage.DataAccess.Impl.EntityConfigurations;

public sealed class SecretEntityTypeConfiguration : IEntityTypeConfiguration<Secret>
{
    public void Configure(EntityTypeBuilder<Secret> builder)
    {
        builder.HasKey(s => s.Id);
            
        builder.HasOne<Vault>()
            .WithMany(v => v.Secrets)
            .OnDelete(DeleteBehavior.Cascade);
    }
}