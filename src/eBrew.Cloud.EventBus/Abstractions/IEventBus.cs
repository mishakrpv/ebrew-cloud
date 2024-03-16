using eBrew.Cloud.EventBus.Events;

namespace eBrew.Cloud.EventBus.Abstractions;

public interface IEventBus
{
    Task PublishAsync(IntegrationEvent @event);
}