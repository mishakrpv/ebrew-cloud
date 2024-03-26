var builder = DistributedApplication.CreateBuilder(args);

// var cache = builder.AddRedis("cache");
//
// var eventBus = builder.AddRabbitMQ("eventbus");

var postgres = builder.AddPostgresContainer("postgres");

var keyManagementDb = postgres.AddDatabase("keymanagementdb");
var storageDb = postgres.AddDatabase("storagedb");
var identityDb = postgres.AddDatabase("identitydb");

var identityApi = builder.AddProject<Projects.eBrew_Cloud_Identity_API>("identityapi")
    .WithReference(identityDb)
    .WithLaunchProfile("https");

var idpHttps = identityApi.GetEndpoint("https");

var keyManagementApi = builder.AddProject<Projects.eBrew_Cloud_KeyManagement_API>("keymanagement")
    .WithReference(keyManagementDb)
    .WithEnvironment("Identity__Url", idpHttps);

var storageApi = builder.AddProject<Projects.eBrew_Cloud_Storage_API>("storageapi")
    .WithReference(storageDb)
    .WithReference(keyManagementApi);

var webApp = builder.AddProject<Projects.eBrew_Cloud_WebApp>("webapp")
    .WithReference(keyManagementApi)
    // .WithReference(eventBus)
    .WithLaunchProfile("https");

builder.Build().Run();
