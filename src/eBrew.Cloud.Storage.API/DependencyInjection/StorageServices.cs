using eBrew.Cloud.Storage.API.Infrastructure.ServiceInterfaces;
using eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;

namespace eBrew.Cloud.Storage.API.DependencyInjection;

public sealed class StorageServices(
    IVaultRepository repository,
    IKeyManagementService keyManager,
    ILogger<StorageServices> logger)
{
    public IVaultRepository Repository { get; } = repository;
    
    public IKeyManagementService KeyManager { get; } = keyManager;
    
    public ILogger<StorageServices> Logger { get; }= logger;
}