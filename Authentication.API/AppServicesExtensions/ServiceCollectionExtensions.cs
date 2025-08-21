using Authentication.API.Data;
using Authentication.API.Models;
using Authentication.API.Services;
using Authentication.API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace Authentication.API.AppServicesExtensions;

public static class ServiceCollectionExtensions
{
  public static WebApplicationBuilder AddAuthParameters(this WebApplicationBuilder builder)
  {
    builder.Services.AddIdentity<User, Role>();

    builder.Services.AddIdentityCore<User>(options =>
    {
      options.Password.RequireDigit = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireLowercase = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredLength = 4;

      options.SignIn.RequireConfirmedEmail = false;
      options.SignIn.RequireConfirmedPhoneNumber = false;
    })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<AuthApiContext>()
                .AddDefaultTokenProviders();

    return builder;
  }

}