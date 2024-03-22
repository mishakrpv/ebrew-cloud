using eBrew.Cloud.KeyManagement.API.Infrastructure;
using eBrew.Cloud.KeyManagement.API.Infrastructure.ServiceInterfaces;
using eBrew.Cloud.KeyManagement.Infrastructure;
using MediatR;

namespace eBrew.Cloud.KeyManagement.API.DependencyInjection;

public sealed class KeyManagementServices(
    IMediator mediator,
    IIdentityService identityService,
    ILogger<KeyManagementServices> logger)
{
    public IMediator Mediator { get; } = mediator;
    
    public IIdentityService IdentityService { get; } = identityService;
    
    public ILogger<KeyManagementServices> Logger { get; } = logger;
}