using Authentication.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Data
{
  public class AuthApiContext : IdentityDbContext<User, Role, Guid,
                                                      IdentityUserClaim<Guid>, UserRoles, IdentityUserLogin<Guid>,
                                                      IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
  {
    public AuthApiContext(DbContextOptions<AuthApiContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<UserRoles>(userRole =>
      {
        userRole.HasOne(ur => ur.Role)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.RoleId)
                      .IsRequired();

        userRole.HasOne(ur => ur.User)
                      .WithMany(r => r.UserRoles)
                      .HasForeignKey(ur => ur.UserId)
                      .IsRequired();
      });
    }
  }
}