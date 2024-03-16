using eBrew.Cloud.ServiceDefaults;
using eBrew.Cloud.Storage.API.Apis;
using eBrew.Cloud.Storage.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseDefaultOpenApi();

app.MapDefaultEndpoints();

app.MapGroup("/api/v1/storage")
    .WithTags("Storage API")
    .MapStorageApi();

app.Run();