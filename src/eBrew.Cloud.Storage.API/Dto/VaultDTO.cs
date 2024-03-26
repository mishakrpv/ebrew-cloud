using System.ComponentModel.DataAnnotations;

namespace eBrew.Cloud.Storage.API.Dto;

public sealed class VaultDTO
{
    [Required, MaxLength(100)] public required string Name { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; } = null!;
}