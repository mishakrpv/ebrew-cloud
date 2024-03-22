var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgresContainer("postgres");

var keyManagementDb = postgres.AddDatabase("keymanagementdb");
var storageDb = postgres.AddDatabase("storagedb");

var cache = builder.AddRedis("cache");

var eventBus = builder.AddRabbitMQ("eventbus");

var keyManagementApi = builder.AddProject<Projects.eBrew_Cloud_KeyManagement_API>("keymanagement")
    .WithReference(keyManagementDb);

var storageApi = builder.AddProject<Projects.eBrew_Cloud_Storage_API>("storageapi")
    .WithReference(storageDb)
    .WithReference(keyManagementApi);

var webApp = builder.AddProject<Projects.eBrew_Cloud_WebApp>("webapp")
    .WithReference(keyManagementApi)
    .WithReference(eventBus)
    .WithLaunchProfile("https");

builder.Build().Run();
