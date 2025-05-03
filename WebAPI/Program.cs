using Infraestructura.Persistencia.Configuraciones;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuración de Kestrel para https para proteger en CICD expuesto
string certPath = Environment.GetEnvironmentVariable("CERT_PATH_DESAPPS_BACK") ?? throw new InvalidOperationException("Certificado no definido");
string certPassword = Environment.GetEnvironmentVariable("CERT_PASS_DESAPPS_BACK") ?? throw new InvalidOperationException("Contraseña del certificado no definida");
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    //serverOptions.ListenAnyIP(5000); // HTTP
    serverOptions.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(certPath, certPassword);
    });
});

// DbContext injection
builder.Services.AddDbContext<ProjectContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
// Acá se agregó la creación y migración automática de la base de datos
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
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
