using eBrew.Cloud.KeyManagement.API.Infrastructure;
using Grpc.Core;
using MediatR;

namespace eBrew.Cloud.KeyManagement.API.Grpc;

public sealed class KeyManagementService(
    IMediator context,
    ILogger<KeyManagementService> logger) : KeyManagement.KeyManagementBase
{
    public async override Task<AuthorizeResponse> AuthorizeApiKey(AuthorizeRequest request, ServerCallContext context)
    {
        throw new NotImplementedException();
    }
}