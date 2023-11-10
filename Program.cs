using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);

builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpLogging();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/person", () => new Person("A","B") );

app.Run();

public record Person(string FirstName, string LastName);
