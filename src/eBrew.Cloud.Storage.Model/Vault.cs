namespace eBrew.Cloud.Storage.Model;

public sealed class Vault(string userId, string name, string? description)
{
    public string UserId { get; } = userId;

    public string Name { get; set; } = name;

    public string? Description { get; set; } = description;
    
    private List<Secret> _secrets = [];

    public IEnumerable<Secret> Secrets => _secrets.AsReadOnly();
    
    public DateTime CreationDate { get; } = DateTime.UtcNow;

    public void Add(Secret secret)
    {
        _secrets.Add(secret);
    } 

    public bool Remove(Secret secret)
    {
        return _secrets.Remove(secret);
    }
}