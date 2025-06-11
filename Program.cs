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

var Products = new List<Product>()
{
    new Product("Apple",20),
    new Product("Banana",10),
 };

app.MapGet("/products", () =>
{
    return Results.Ok(Products);       // 200
});


app.Run();

public record Product(string Name, int Price);
