using Church.API.AppServicesExtensions;
using Church.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Repositories;
using Shared.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Services Configuration
builder.AddApiSwagger();
builder.AddPersistence<ChurchContext>("ChurchDB");
builder.Services.AddCors();
builder.AddAuthenticationJwt();
builder.AddJsonConfiguration();

// Repositories
builder.Services.AddScoped<IGeneralRepository, GeneralRepository<ChurchContext>>();

var app = builder.Build();

// Endpoints Configuration


// Middlewares
var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Migrations Database Update
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ChurchContext>();

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
