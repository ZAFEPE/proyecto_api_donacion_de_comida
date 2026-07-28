using API_DONACIONES.DataBase;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add database service
builder.Services.AddDbContext<DonacionesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Inyección de dependencias de tus servicios personales (Agrega tus interfaces y servicios aquí)
// builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllers();

// Configuración para OpenAPI (Soporte nativo de .NET 9 para Scalar)
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Solo se habilita en entorno de desarrollo
{
    app.MapOpenApi();
    
    // Interfaz visual interactiva de Scalar para probar tu API
    app.MapScalarApiReference(options =>
    {
        options.Title = "API Donaciones";
        options.Theme = ScalarTheme.Purple; // Puedes cambiar el tema si deseas (e.g. Moon, Dark, etc.)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();