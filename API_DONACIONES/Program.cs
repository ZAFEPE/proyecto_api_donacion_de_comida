using API_DONACIONES.DataBase;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DonacionesDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddControllers();


builder.Services.AddOpenApi();

var app = builder.Build();

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