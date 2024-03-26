using Duende.IdentityServer.Models;
using eBrew.Cloud.Identity.API;
using Microsoft.AspNetCore.Identity;
using eBrew.Cloud.Identity.API.Data;
using eBrew.Cloud.Identity.API.Model;
using eBrew.Cloud.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<IdentityContext>("identitydb", 
    static settings => { });

// builder.Services.AddMigration<IdentityContext, UserSeed>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(options =>
    {

    });

builder.Services.AddIdentityServer(options =>
    {
        options.EmitStaticAudienceClaim = true;
        
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
    })
    .AddInMemoryIdentityResources(new List<IdentityResource>())
    .AddInMemoryApiScopes(new List<ApiScope>())
    .AddInMemoryApiResources(new List<ApiResource>())
    .AddInMemoryClients(new List<Client>());

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