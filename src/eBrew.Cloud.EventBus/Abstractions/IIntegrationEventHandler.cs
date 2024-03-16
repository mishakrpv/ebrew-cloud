using eBrew.Cloud.EventBus.Events;

namespace eBrew.Cloud.EventBus.Abstractions;

public interface IIntegrationEventHandler<in T> where T : IntegrationEvent
{
    Task Handle(T @event);
}