using HomeCare.N8N.Application.Medications.Interfaces;
using HomeCare.N8N.Application.Medications.Services;
using HomeCare.N8N.Data.Context;
using HomeCare.N8N.Data.Medications.Interfaces;
using HomeCare.N8N.Data.Medications.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default")));

// Register repositories
builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();

// Register services
builder.Services.AddScoped<IMedicationService, MedicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // Garante que o schema 'dev' exista antes de rodar as migrations
        context.Database.ExecuteSqlRaw("CREATE SCHEMA IF NOT EXISTS dev;");

        // Aplica todas as migrations pendentes no Postgres
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations no banco.");
    }
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
