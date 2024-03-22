using Ardalis.Result;
using eBrew.Cloud.KeyManagement.API.Grpc;
using eBrew.Cloud.Storage.API.Infrastructure.ServiceInterfaces;
using Grpc.Net.Client;

namespace eBrew.Cloud.Storage.API.Infrastructure.Services;

public sealed class GrpcKeyManagementService(IConfiguration config) : IKeyManagementService
{
    public async Task<Result<string>> AuthorizeKeyAsync(string key)
    {
        using (var channel = GrpcChannel.ForAddress(config["KeyManagementUrl"]!))
        {
            var client = new KeyManagement.API.Grpc.KeyManagement.KeyManagementClient(channel);
            var response = await client.AuthorizeApiKeyAsync(new AuthorizeRequest() { Key = key });

            if (!response.Succeeded)
            {
                return Result.Forbidden();
            }

            return Result.Success(response.UserId);
        }
    }
}