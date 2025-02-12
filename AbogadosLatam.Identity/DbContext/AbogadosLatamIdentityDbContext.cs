using AbogadosLatam.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbogadosLatam.Identity.DbContext;

public class AbogadosLatamIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AbogadosLatamIdentityDbContext(DbContextOptions<AbogadosLatamIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AbogadosLatamIdentityDbContext).Assembly);
    }
}