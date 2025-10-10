// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
//     app.UseSwaggerUi(options =>
//     {
//         options.DocumentPath = "/openapi/v1.json";
//     });
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using moon_light_rest_api.Repositories;
using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Dapper IDbConnection
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));

// FluentMigrator ekle
builder.Services
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres() // PostgreSQL kullanıyorsun
        .WithGlobalConnectionString(connectionString)
        .ScanIn(typeof(Program).Assembly).For.Migrations()) // Migrations klasörünü tarar
    .AddLogging(lb => lb.AddFluentMigratorConsole());

// Repository
builder.Services.AddScoped<IParentRepository, ParentRepository>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ MIGRATIONS’I OTOMATİK ÇALIŞTIR
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp(); // <-- işte tabloyu burada oluşturur
}


// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "School API V1");
});

app.MapControllers();

app.Run();
