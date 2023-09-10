using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GarageLib
{
    public class GarageContext : DbContext
    {
        public DbSet<Garage> Garages { get; set; } 
        public DbSet<Worker> Workers {get; set;}
        public DbSet<Vehicle> Vehicles { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ManyToManyGarageDB"
            );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Garage>(g =>
            {
                g.OwnsMany(g => g.Vehicles);
                g.HasMany(g => g.Workers).WithMany(w => w.Garages);
            });
        }
    }
}
