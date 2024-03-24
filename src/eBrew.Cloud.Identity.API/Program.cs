using Microsoft.AspNetCore.Identity;
using eBrew.Cloud.Identity.API.Data;
using eBrew.Cloud.Identity.API.Extensions;
using eBrew.Cloud.Identity.API.Model;
using eBrew.Cloud.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<IdentityContext>("identitydb");

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    
});

builder.Services.AddIdentityServer(options =>
{
    options.IssuerUri = "null";
    options.Authentication.CookieLifetime = TimeSpan.FromHours(2);

    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseStaticFiles();
app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();

app.Run();