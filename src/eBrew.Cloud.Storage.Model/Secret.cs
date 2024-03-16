namespace eBrew.Cloud.Storage.Model;

public sealed class Secret
{
    public Secret(string vaultId, string key, string value)
    {
        VaultId = vaultId;
        Key = key;
        Value = value;
    }

    public string Id { get; } = Guid.NewGuid().ToString();
    
    public string VaultId { get; } = null!;

    public string Key { get; } = null!;

    public string Value { get; } = null!;

    private Secret() { }
}