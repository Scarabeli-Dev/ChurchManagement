var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("cache");

// Postgres Parameters
var username = builder.AddParameter("postgres-username", secret: true);
var password = builder.AddParameter("postgres-password", secret: true);

var postgres = builder.AddPostgres("postgres", userName: username, password: password, port: 5432)
                     .WithLifetime(ContainerLifetime.Persistent)
                     .WithPgAdmin();

var authDB = postgres.AddDatabase("AuthDB");
var churchDB = postgres.AddDatabase("ChurchDB");
var membersDB = postgres.AddDatabase("MembersDB");

var authApi = builder.AddProject<Projects.Authentication_API>("authApi")
                     .WithReference(authDB)
                     .WaitFor(postgres);

var churchApi = builder.AddProject<Projects.Church_API>("churchApi")
                    .WithReference(churchDB)
                    .WaitFor(postgres);

var membersApi = builder.AddProject<Projects.Members_API>("membersApi")
                    .WithReference(membersDB)
                    .WaitFor(postgres);


builder.AddNpmApp("vue", "../ChurchManagement.Vue", "dev", ["--host"])
    .WithReference(authApi)
    .WithReference(churchApi)
    .WaitFor(authApi)
    .WaitFor(churchApi)
    .WithHttpEndpoint(env: "PORT", port: 5173)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
