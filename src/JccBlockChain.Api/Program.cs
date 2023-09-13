var builder = WebApplication.CreateBuilder(args);

// Todo create proto files and configuration
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();