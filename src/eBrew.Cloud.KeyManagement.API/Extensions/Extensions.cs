using eBrew.Cloud.KeyManagement.API.Infrastructure.ServiceInterfaces;
using eBrew.Cloud.KeyManagement.API.Infrastructure.Services;
using eBrew.Cloud.KeyManagement.Application.Mapping;
using eBrew.Cloud.KeyManagement.Infrastructure;
using eBrew.Cloud.ServiceDefaults;

namespace eBrew.Cloud.KeyManagement.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
            
        builder.AddDefaultAuthentication();

        builder.Services.AddTransient<IIdentityService, IdentityService>();
        
        builder.AddNpgsqlDbContext<KeyManagementContext>("apikeymanagementdb");
    }
}