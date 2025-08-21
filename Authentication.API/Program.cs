using Authentication.API.ApiEndpoints;
using Authentication.API.AppServicesExtensions;
using Authentication.API.Data;
using Authentication.API.Services;
using Authentication.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Services Configuration
builder.AddApiSwagger();
builder.AddPersistence<AuthApiContext>("AuthDB");
builder.Services.AddCors();
builder.AddAuthenticationJwt(); 
builder.AddAuthParameters();
builder.AddJsonConfiguration();

builder.Services.AddScoped<ITokenService, TokenService>();


var app = builder.Build();

// Endpoints Configuration
app.MapAuthEndpoints();
app.MapRolesEndpoints();
app.MapUsersEndpoints();

// Middlewares
var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Migrations Database Update
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AuthApiContext>();

    try
    {
        db.Database.Migrate();
        Console.WriteLine("✅ Migrations applied successfully!");
        var pending = db.Database.GetPendingMigrations();
        if (!pending.Any())
        {
            Console.WriteLine("Nenhuma migração pendente.");
        }
        else
        {
            Console.WriteLine($"{pending.Count()} migration(s) pendente(s).");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Migration failed: {ex.Message}");
        throw; // Opcional, relança a exceção se quiser falhar a execução
    }
}

app.Run();
