using eBrew.Cloud.Identity.API.Data;
using eBrew.Cloud.Identity.API.Model;
using Microsoft.AspNetCore.Identity;

namespace eBrew.Cloud.Identity.API;

public sealed class UserSeed(ILogger<UserSeed> logger, UserManager<ApplicationUser> userManager) : IDbSeeder<IdentityContext>
{
    public async Task SeedAsync(IdentityContext context)
    {
        var alex = await userManager.FindByNameAsync("alex");

        string alexLoggerDebugMessage;

        if (alex is null)
        {
            alex = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "alex",
                Email = "AlexKalinkov@email.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(alex, "StrongPass14?");

            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }

            alexLoggerDebugMessage = "alex created.";
        }
        else
        {
            alexLoggerDebugMessage = "alex aldready created.";
        }

        if (logger.IsEnabled(LogLevel.Debug))
        {
            logger.LogDebug(alexLoggerDebugMessage);
        }
    }
}