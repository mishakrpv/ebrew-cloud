using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var eventBus = builder.AddRabbitMQ("eventbus");

var storageApi = builder.AddProject<Projects.eBrew_Cloud_Storage_API>("storageapi")
    .WithReference(cache);

builder.Build().Run();
