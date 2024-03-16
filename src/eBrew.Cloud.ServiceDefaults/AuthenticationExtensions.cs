using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.JsonWebTokens;

namespace eBrew.Cloud.ServiceDefaults;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddDefaultAuthentication(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var config = builder.Configuration;

        // {
        //   "Identity": {
        //     "Url": "http://identity",
        //     "Audience": "service"
        //    }
        // }

        var identitySection = config.GetSection("Identity");

        if (!identitySection.Exists())
        {
            return services;
        }

        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

        services.AddAuthentication().AddJwtBearer(options =>
        {
            var identityUrl = identitySection.GetRequiredValue("Url");
            var audience = identitySection.GetRequiredValue("Audience");

            options.Authority = identityUrl;
            options.RequireHttpsMetadata = false;
            options.Audience = audience;
            options.TokenValidationParameters.ValidateAudience = false;
        });

        services.AddAuthorization();

        return services;
    }
}