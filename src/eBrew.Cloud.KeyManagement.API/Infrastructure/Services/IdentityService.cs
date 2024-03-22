using eBrew.Cloud.KeyManagement.API.Infrastructure.ServiceInterfaces;

namespace eBrew.Cloud.KeyManagement.API.Infrastructure.Services;

public sealed class IdentityService(IHttpContextAccessor context) : IIdentityService
{
    public string? GetUserIdentity()
        => context.HttpContext?.User.FindFirst("sub")?.Value;
}