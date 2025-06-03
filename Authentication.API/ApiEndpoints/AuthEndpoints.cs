using Authentication.APIData;
using Authentication.APIModels;
using Authentication.APIModels.ViewModels;
using Authentication.APIServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.APIApiEndpoints;

public static class AuthEndpoints
{
  public static void MapAuthEndpoints(this WebApplication app)
  {
    app.MapPost("/login", [AllowAnonymous] async
        (UserLoginViewModel userLoginVM,
        ITokenService tokenService,
        SignInManager<User> signInManager,
        UserManager<User> userManager) =>
    {
      var userLogin = await userManager.Users.SingleOrDefaultAsync(user => user.UserName == userLoginVM.UserName);
      if (userLogin != null)
      {
        var result = await signInManager.CheckPasswordSignInAsync(userLogin, userLoginVM.Password, false);
        if (result.Succeeded)
        {
          var roles = await userManager.GetRolesAsync(userLogin);

          var tokenString = tokenService.CreateToken(
                  userLogin,
                  roles.ToList(),
                  app.Configuration["Jwt:Key"],
                  app.Configuration["Jwt:Issuer"],
                  app.Configuration["Jwt:Audience"]);
          return Results.Ok(new { token = tokenString });
        }
      }
      return Results.BadRequest("Login Inválido");
    }).Produces(StatusCodes.Status400BadRequest)
      .Produces(StatusCodes.Status200OK)
      .WithName("Login")
      .WithTags("Autenticacao");
  }
}