var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/users", () => "Hello World!");

app.Run();