using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add Controller Service
builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(Options =>
{
    Options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Where(e => e.Value != null && e.Value.Errors.Count > 0).Select(e => new
        {
            Field = e.Key,
            Errors = e.Value != null ? e.Value.Errors.Select(x => x.ErrorMessage).ToArray() : new string[0]
                }).ToList();

        return new BadRequestObjectResult(new
        {
            Message = "Validation Failed.",
            Errors = errors
        });
    };
});
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


app.MapControllers();
app.Run();



                                        