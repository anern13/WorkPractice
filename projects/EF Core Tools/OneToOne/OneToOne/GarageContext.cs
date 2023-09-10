using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class GarageContext : DbContext
    {
        public DbSet<Worker> Workers { set; get; }
        public DbSet<Vehicle> Vehicles { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OneToOneDB"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Vehicle>(v => v
            //    .HasOne(v => v.Worker)
            //    .WithOne(w => w.Vehicle)
            //    .HasForeignKey<Worker>(w => w.VehicleId)
            //    .IsRequired(false)
            //);
        }
    }
}
