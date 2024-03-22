namespace eBrew.Cloud.KeyManagement.Entities;

public sealed class ApiKey
{
    public ApiKey(string userId, string secretKey, string? description = null)
    {
        UserId = userId;
        SecretKey = secretKey;
        Description = description;
    }

    public string Id { get; } = Guid.NewGuid().ToString().Replace('-', '\0');
    
    private string UserId { get; } = null!;
    
    public string SecretKey { get; } = null!;

    public string? Description { get; set; }
    
    private ApiKey() { }
}