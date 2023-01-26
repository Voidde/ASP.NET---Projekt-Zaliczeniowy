using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projekt.Areas.Identity.Data;

namespace Projekt.Areas.Identity.Data;

public class IdentityAppDbContext : IdentityDbContext<User>
{
    public IdentityAppDbContext(DbContextOptions<IdentityAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Tworzenie ról
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1",Name = "Admin", NormalizedName ="ADMIN".ToUpper()},
            new IdentityRole { Id = "2",Name = "User", NormalizedName = "USER".ToUpper()}      
        );

        var hasher = new PasswordHasher<IdentityUser>();

        //Tworzenie uzytkownikow
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser { Id = "1", UserName = "TestUser", NormalizedUserName = "TESTUSER".ToUpper(), Email = "TestUser@mail.com", NormalizedEmail = "TESTUSER@MAIL.COM", PasswordHash = hasher.HashPassword(null, "Pa$sword123") },
            new IdentityUser
            {
                Id = "2",
                UserName = "Admin",
                NormalizedUserName = "ADMIN".ToUpper(),
                Email = "Admin@mail.com",
                NormalizedEmail = "Admin@MAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Pa$sword123")
            }
            );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId= "1",
                UserId= "2",
            },
            new IdentityUserRole<string>()
            {
                RoleId="2",
                UserId= "1",
            });

    }
}
