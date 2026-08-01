using API_DONACIONES.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_DONACIONES.DataBase
{
    public class DonacionesDbContext : DbContext
    {
        public DonacionesDbContext (DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<DonationEntity> Donations { get; set; }
        public DbSet<DonorEntity> Donors { get; set; }
    }
}