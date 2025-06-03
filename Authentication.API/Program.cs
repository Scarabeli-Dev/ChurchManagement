using Authentication.APIApiEndpoints;
using Authentication.APIAppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();
builder.AddAuthParameters();
builder.AddJsonConfiguration();

var app = builder.Build();

app.MapAuthEndpoints();
app.MapRolesEndpoints();
app.MapUsersEndpoints();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
var environment = app.Environment;
app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseHttpsRedirection();

app.Run();