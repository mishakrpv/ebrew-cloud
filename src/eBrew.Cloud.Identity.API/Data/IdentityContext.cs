using eBrew.Cloud.Identity.API.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBrew.Cloud.Identity.API.Data;

public sealed class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options) { }
}