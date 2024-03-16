using eBrew.Cloud.Storage.DataAccess.Interfaces.Repositories;
using eBrew.Cloud.Storage.Model;

namespace eBrew.Cloud.Storage.DataAccess.Impl.Repositories;

public sealed class EFVaultRepository : IVaultRepository
{
    private readonly StorageContext _context;

    public EFVaultRepository(StorageContext context)
    {
        _context = context;
    }

    public async Task<Vault> CreateVaultAsync(Vault vault)
    {
        _context.Add(vault);
        await _context.SaveChangesAsync();

        return vault;
    }

    public async Task<Vault?> GetVaultAsync(string name, string userId)
    {
        return await _context.FindAsync<Vault>(new object[] { name, userId });
    }

    public async Task<Vault> UpdateVaultAsync(Vault vault)
    {
        _context.Update(vault);
        await _context.SaveChangesAsync();

        return vault;
    }

    public async Task<bool> DeleteVaultAsync(string name, string userId)
    {
        var vault = await this.GetVaultAsync(name, userId);

        if (vault is not null)
        {
            _context.Remove(vault);
            
            return true;
        }

        return false;
    }
}