// GitSomeJava — Order API
//
// Deliberately boring. The application is not the demo; the supply chain
// around it is. Anything clever here would pull attention away from the
// controls, which is the opposite of what this session needs.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks("/healthz");

app.MapGet("/", () => Results.Ok(new
{
    service = "gitsomejava-order-api",
    status = "brewing",
    // Stamped at build time by the pipeline so you can prove on stage that
    // the running artifact is the one the attestation covers.
    version = Environment.GetEnvironmentVariable("APP_VERSION") ?? "dev",
    commit = Environment.GetEnvironmentVariable("APP_COMMIT") ?? "local",
    builtBy = Environment.GetEnvironmentVariable("APP_BUILD_URL") ?? "not-a-pipeline"
}));

app.MapGet("/orders/{id:int}", (int id) => Results.Ok(new { id, item = "Flat white" }));

app.MapGet("/orders", () => Results.Ok(new[]
{
    new { id = 1, item = "Flat white", size = "Regular" },
    new { id = 2, item = "Cold brew", size = "Large" }
}));

app.Run();
