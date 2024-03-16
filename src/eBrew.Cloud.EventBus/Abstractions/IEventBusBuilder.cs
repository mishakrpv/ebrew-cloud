using Microsoft.Extensions.DependencyInjection;

namespace eBrew.Cloud.EventBus.Abstractions;

public interface IEventBusBuilder
{
    public IServiceCollection Services { get; }
}