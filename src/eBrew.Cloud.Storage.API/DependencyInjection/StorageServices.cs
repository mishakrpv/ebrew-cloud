using eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;

namespace eBrew.Cloud.Storage.API.DependencyInjection;

public sealed class StorageServices(
    IVaultRepository repository,
    ILogger<StorageServices> logger)
{
    public IVaultRepository Repository { get; } = repository;

    public ILogger<StorageServices> Logger { get; }= logger;
}