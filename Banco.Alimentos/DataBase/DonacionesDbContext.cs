using Microsoft.EntityFrameworkCore;

namespace API_DONACIONES.DataBase
{
    public class DonacionesDbContext : DbContext
    {
        public DonacionesDbContext (DbContextOptions options) : base(options)
        {
            
        }

        // public DbSet<CategoryEntity> Categories { get; set; }
        /*Un DbSet representa una tabla completa dentro de tu base de datos.

        <CategoryEntity>: Le dice a Entity Framework cuál es el molde (las columnas) que va a tener esa tabla.

        Categories: Es el nombre que tendrá la tabla en la base de datos y el nombre de la propiedad que
        vas a usar en tu código para hacer consultas (por ejemplo: _context.Categories.ToList()).*/

    }
}