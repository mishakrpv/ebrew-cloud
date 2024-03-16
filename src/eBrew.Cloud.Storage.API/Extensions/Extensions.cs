using eBrew.Cloud.Storage.DataAccess.Impl;
using eBrew.Cloud.Storage.DataAccess.Impl.Repositories;
using eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;

namespace eBrew.Cloud.Storage.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<StorageContext>("storagedb");

        builder.Services.AddScoped<IVaultRepository, EFVaultRepository>();
    }
}