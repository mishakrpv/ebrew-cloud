using eBrew.Cloud.KeyManagement.Entities;
using eBrew.Cloud.KeyManagement.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace eBrew.Cloud.KeyManagement.Infrastructure;

public sealed class KeyManagementContext : DbContext
{
    public KeyManagementContext(DbContextOptions<KeyManagementContext> options) : base(options)
    { }
    
    public DbSet<ApiKey> ApiKeys { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ApiKeyTypeConfiguration());
    }
}