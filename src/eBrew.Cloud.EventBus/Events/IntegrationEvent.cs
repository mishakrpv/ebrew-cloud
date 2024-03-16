using System.Text.Json.Serialization;

namespace eBrew.Cloud.EventBus.Events;

public record IntegrationEvent
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [JsonInclude] public DateTime CreationDate { get; set; } = DateTime.UtcNow;
}