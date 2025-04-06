using DotNetEnv;
using Infraestructura.Persistencia.Configuraciones;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file only in development mode
if (builder.Environment.IsDevelopment()) Env.Load(".env");

// DbContext injection
builder.Services.AddDbContext<ProjectContext>(options => options.UseMySQL(Environment.GetEnvironmentVariable("STRING_CONNECTION") ?? string.Empty));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Migrations only in development mode
    using (var serviceScope = app.Services.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetRequiredService<ProjectContext>();
        context.Database.Migrate();
    }
    // Acá hubo que adaptar la compatibilidad de la versión de Swagger
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
