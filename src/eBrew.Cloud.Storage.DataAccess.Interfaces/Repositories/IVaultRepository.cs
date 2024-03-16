using eBrew.Cloud.Storage.Model;

namespace eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;

public interface IVaultRepository
{
    Task<Vault> CreateVaultAsync(Vault vault);

    Task<Vault?> GetVaultAsync(string name, string userId);

    Task<Vault> UpdateVaultAsync(Vault vault);

    Task<bool> DeleteVaultAsync(string name, string userId);
}