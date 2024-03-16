﻿using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace eBrew.Cloud.EventBus.Abstractions;

public sealed class EventBusSubscriptionInfo
{
    public Dictionary<string, Type> EventTypes { get; } = [];
    
    public JsonSerializerOptions JsonSerializerOptions { get; } = new(DefaultSerializerOptions);
    
    internal static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        TypeInfoResolver = JsonSerializer.IsReflectionEnabledByDefault ? CreateDefaultTypeResolver() : JsonTypeInfoResolver.Combine()
    };
    
    private static IJsonTypeInfoResolver CreateDefaultTypeResolver() => new DefaultJsonTypeInfoResolver();
}