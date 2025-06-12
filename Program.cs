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

List<Catagory> catagories = new List<Catagory>();

// Minimal API endpoints
app.MapGet("/", () =>
{
    return "get method worked";
});

// GET catagories => /api/catagories

app.MapGet("/api/catagories", () =>
{
    return Results.Ok(catagories);       // 200
});

app.MapPost("/api/catagories", () =>
{
    var newCatagory = new Catagory
    {
        CatagoryId = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"),
        Name = "Electronics",
        Description = "Phone, Laptop, SmartWatch, etc...",
        CreatedAt = DateTime.UtcNow
    };
    catagories.Add(newCatagory);
    return Results.Created($"api/catagories/{newCatagory.CatagoryId}",newCatagory);       // 200
});

app.MapDelete("/api/catagories", () =>
{
    var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"));       // 200
    if (foundCatagory == null)
    {
        return Results.NotFound("Catagory with this id does not exist.");
    }
    catagories.Remove(foundCatagory);
    return Results.NoContent();
});

app.MapPut("/api/catagories", () =>
{
    var foundCatagory = catagories.FirstOrDefault(catagory => catagory.CatagoryId == Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301"));       // 200
    if (foundCatagory == null)
    {
        return Results.NotFound("Catagory with this id does not exist.");
    }
    foundCatagory.Name = "SmartPhone";
    foundCatagory.Description = "Samsung, Vivo, Redmi";
    return Results.NoContent();
});

app.Run();

public record Catagory
{
    public Guid CatagoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
