using eBrew.Cloud.KeyManagement.API.Infrastructure.ServiceInterfaces;
using eBrew.Cloud.KeyManagement.API.Infrastructure.Services;
using eBrew.Cloud.KeyManagement.Application.Mapping;
using eBrew.Cloud.KeyManagement.Infrastructure;
using eBrew.Cloud.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace eBrew.Cloud.KeyManagement.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddAutoMapper(typeof(MappingProfile));
            
        builder.AddDefaultAuthentication();
        
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddTransient<IIdentityService, IdentityService>();
        
        builder.AddNpgsqlDbContext<KeyManagementContext>("apikeymanagementdb");
    }
}