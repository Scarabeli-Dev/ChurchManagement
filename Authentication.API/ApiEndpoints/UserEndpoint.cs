using Authentication.APIData;
using Authentication.APIModels;
using Authentication.APIModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.APIApiEndpoints;

public static class UsersEndpoints
{
  public static void MapUsersEndpoints(this WebApplication app)
  {
    app.MapGet("/user", [AllowAnonymous] async (AuthApiContext db) =>
    {

      return await db.Users.Include(ur => ur.UserRoles)
                               .ThenInclude(r => r.Role)
                               .ToListAsync()
           is List<User> users
           ? Results.Ok(users)
           : Results.NotFound();

    }).Produces(StatusCodes.Status400BadRequest)
      .Produces(StatusCodes.Status200OK)
      .WithTags("Usuarios");

    app.MapPost("/register", [AllowAnonymous] async
        (RegisterViewModel userRegister,
        UserManager<User> userManager,
        RoleManager<Role> roleManager) =>
    {
      try
      {
        var userExist = await userManager.FindByEmailAsync(userRegister.Email);
        if (userExist != null) return Results.BadRequest("Usuário já existe!");

        User user = new User()
        {
          UserName = userRegister.UserName,
          Email = userRegister.Email,
          PhoneNumber = userRegister.PhoneNumber,
          CPF = userRegister.CPF,
        };

        var result = await userManager.CreateAsync(user, userRegister.Password);
        if (!result.Succeeded) return Results.BadRequest("Erro ao cadastrar usuário");

        var newUser = await userManager.FindByEmailAsync(user.Email);

        foreach (var role in userRegister.Roles)
        {
          var roleVerify = roleManager.FindByNameAsync(role);
          if (roleVerify.Result == null)
          {
            Role newRole = new Role()
            {
              Name = role,
            };

            await roleManager.CreateAsync(newRole);
          }

          await userManager.AddToRoleAsync(newUser, role);
        }

        return Results.Ok("Usuário cadastrado com sucesso");
      }
      catch (Exception ex)
      {
        throw new Exception($"Erro ao tentar cadastrar usuário. Erro: {ex.Message}");
      }
    }).Produces(StatusCodes.Status400BadRequest)
      .Produces(StatusCodes.Status200OK)
      .WithName("Registro")
      .WithTags("Usuarios");


    app.MapDelete("/user/{id:Guid}", async (Guid id, AuthApiContext db, UserManager<User> userManager) =>
    {
      var user = await userManager.FindByIdAsync(id.ToString());

      if (user == null) return Results.NotFound("Usuário não encontrado!");

      var result = userManager.DeleteAsync(user);

      return Results.NoContent();
    }).Produces(StatusCodes.Status400BadRequest)
     .Produces(StatusCodes.Status200OK)
     .WithName("Apagar")
     .WithTags("Usuarios");
  }
}