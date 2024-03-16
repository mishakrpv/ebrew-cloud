using eBrew.Cloud.Storage.DataAccess.Impl.EntityConfigurations;
using eBrew.Cloud.Storage.Model;
using Microsoft.EntityFrameworkCore;

namespace eBrew.Cloud.Storage.DataAccess.Impl;

public sealed class StorageContext : DbContext
{
    public StorageContext(DbContextOptions<StorageContext> options) : base(options)
    { }
    
    public DbSet<Vault> Vaults { get; set; }
    public DbSet<Secret> Secrets { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new VaultEntityTypeConfiguration());
        builder.ApplyConfiguration(new SecretEntityTypeConfiguration());
    }
}