using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using eBrew.Cloud.EventBus.Abstractions;
using eBrew.Cloud.EventBus.Events;
using Microsoft.Extensions.DependencyInjection;

namespace eBrew.Cloud.EventBus.Extensions;

public static class EventBusBuilderExtensions
{
    public static IEventBusBuilder ConfigureJsonOptions(this IEventBusBuilder eventBusBuilder, Action<JsonSerializerOptions> configure)
    {
        eventBusBuilder.Services.Configure<EventBusSubscriptionInfo>(options =>
        {
            configure(options.JsonSerializerOptions);
        });

        return eventBusBuilder;
    }

    public static IEventBusBuilder AddSubscription<TEvent, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] THandler>(this IEventBusBuilder eventBusBuilder)
        where TEvent : IntegrationEvent
        where THandler : class, IIntegrationEventHandler<TEvent>
    {
        eventBusBuilder.Services.AddKeyedTransient<IIntegrationEventHandler<TEvent>, THandler>(typeof(TEvent));

        eventBusBuilder.Services.Configure<EventBusSubscriptionInfo>(options =>
        {
            options.EventTypes[typeof(TEvent).Name] = typeof(TEvent);
        });

        return eventBusBuilder;
    }
}
