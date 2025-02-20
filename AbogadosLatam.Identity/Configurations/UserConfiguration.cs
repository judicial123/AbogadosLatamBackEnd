using AbogadosLatam.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AbogadosLatam.Identity.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                PasswordHash = hasher.HashPassword(null, "Admin!123"),
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                Email = "user@localhost.com",
                NormalizedEmail = "USER@LOCALHOST.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user@localhost.com",
                NormalizedUserName = "USER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                EmailConfirmed = true
            }
        );
    }
}