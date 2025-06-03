var builder = DistributedApplication.CreateBuilder(args);

var authApi = builder.AddProject<Projects.Authentication_API>("authApi");

builder.AddNpmApp("vue", "../ChurchManagement.Vue", "dev", ["--host"])
    .WithReference(authApi)
    .WaitFor(authApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
