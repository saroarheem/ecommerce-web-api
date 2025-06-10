var builder = WebApplication.CreateBuilder(args);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger middleware only in development (optional)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API endpoints
app.MapGet("/", () =>
{
    return "get method worked";
});

app.MapGet("/hello", () =>
{
    return "hello from MapGet";
});

app.MapPost("/hello", () =>
{
    return "hello from MapPost";
});

app.MapPut("/hello", () =>
{
    return "hello from MapPut";
});

app.MapDelete("/hello", () =>
{
    return "hello from MapDelete";
});

app.Run();
