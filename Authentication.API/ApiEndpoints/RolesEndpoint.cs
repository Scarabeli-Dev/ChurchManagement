using Authentication.APIData;
using Authentication.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.APIApiEndpoints;

public static class RolesEndpoints
{
  public static void MapRolesEndpoints(this WebApplication app)
  {
    app.MapGet("/roles", [AllowAnonymous] async (AuthApiContext db) =>
await db.Roles.ToListAsync()).WithTags("Roles");

    app.MapGet("/user-role", [AllowAnonymous] async (string role, UserManager<User> userManager, AuthApiContext db) =>
    {
      var usersRole = await userManager.GetUsersInRoleAsync(role);
      return usersRole;
    }).Produces(StatusCodes.Status400BadRequest)
      .Produces(StatusCodes.Status200OK)
      .WithName("UserRole")
      .WithTags("Roles")
      .RequireAuthorization();
  }
}