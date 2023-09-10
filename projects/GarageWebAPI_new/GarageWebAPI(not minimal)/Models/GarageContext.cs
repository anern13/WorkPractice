
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace GarageWebAPI
{
    public class GarageContext : DbContext
    {
        public DbSet<Garage> Garages { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        public GarageContext(DbContextOptions<GarageContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GarageDBNew"
            );
        }

    }
}
