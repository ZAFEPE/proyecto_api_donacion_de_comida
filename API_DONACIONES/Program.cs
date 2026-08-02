using API_DONACIONES.DataBase;
using API_DONACIONES.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DonacionesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddControllers();

// Registrar la interfaz y su clase correspondiente
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonationService, DonationService>();

builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DonacionesDbContext>();
    context.Database.EnsureCreated(); // <--- Crea el archivo .db y sus tablas
}

if (app.Environment.IsDevelopment()) 
{
    app.MapOpenApi();
    
    app.MapScalarApiReference(options =>
    {
        options.Title = "API Donaciones";
        options.Theme = ScalarTheme.Purple; 
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();