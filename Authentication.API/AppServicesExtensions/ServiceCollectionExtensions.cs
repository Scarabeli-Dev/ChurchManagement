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
  public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder)
  {
    builder.Services.AddSwagger();
    return builder;
  }

  public static IServiceCollection AddSwagger(this IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Version = "v1",
        Title = "AuthApi"
      });

      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Description = @"JWT Authorization header usando Bearer.
                                Entre com 'Bearer ' espaço então coloque seu token.
                                Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
      });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[]{}
                }
        });
    });
    return services;
  }

  public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
  {
    builder.Services.AddScoped<ITokenService, TokenService>();

    string npgSqlConnection =
        builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new
        Exception("A string de conexão 'DefaultConnection' não foi configurada.");

    builder.Services.AddDbContext<AuthApiContext>(options =>
                        options.UseNpgsql(npgSqlConnection));

    return builder;
  }

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

  public static WebApplicationBuilder AddAutenticationJwt(this WebApplicationBuilder builder)
  {
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                      };
                    });

    builder.Services.AddAuthorization();
    return builder;
  }

  public static WebApplicationBuilder AddJsonConfiguration(this WebApplicationBuilder builder)
  {
    builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    return builder;
  }

}