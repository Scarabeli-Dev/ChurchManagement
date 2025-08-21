using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared;

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

    public static WebApplicationBuilder AddPersistence<TContext>(this WebApplicationBuilder builder, string databaseName) where TContext : DbContext
    {
        //string connectionString = "";
        //string npgSqlConnection =
        //    connectionName
        //    ?? throw new
        //    Exception("A string de conexão 'DefaultConnection' não foi configurada.");
        //builder.Services.AddDbContext<TContext>(options =>
        //                    options.UseNpgsql(npgSqlConnection));

        //return builder;
        var baseConn = builder.Configuration
            .GetConnectionString("DefaultConnection")
            ?? throw new Exception("Connection string 'DefaultConnection' não encontrada em appsettings.json");

        // 2) Cria um builder para facilitar a troca apenas da propriedade Database
        var npgsqlBuilder = new NpgsqlConnectionStringBuilder(baseConn)
        {
            Database = databaseName
        };

        // 3) Registra o DbContext usando o connectionString modificado
        Console.WriteLine($"Using connection string: {npgsqlBuilder.ConnectionString}");
        builder.Services.AddDbContext<TContext>(options =>
            options.UseNpgsql(npgsqlBuilder.ConnectionString)
        );

        return builder;
    }

    public static WebApplicationBuilder AddAuthenticationJwt(this WebApplicationBuilder builder)
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
