namespace eBrew.Cloud.KeyManagement.Application.Dtos;

public sealed class ApiKeyOneTimeViewDTO
{
    public string Id { get; set; } = null!;

    public string SecretKey { get; set; } = null!;
}