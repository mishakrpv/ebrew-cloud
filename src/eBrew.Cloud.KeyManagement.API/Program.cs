using eBrew.Cloud.KeyManagement.API.Apis;
using eBrew.Cloud.KeyManagement.API.Extensions;
using eBrew.Cloud.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.AddDefaultOpenApi();

var app = builder.Build();

app.UseDefaultOpenApi();

app.MapDefaultEndpoints();

app.MapGroup("/api/v1/keymanagement")
    .WithTags("Key Management API")
    .MapKeyManagementApi();
    
app.Run();