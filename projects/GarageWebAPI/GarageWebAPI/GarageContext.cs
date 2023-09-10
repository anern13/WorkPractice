using GarageDomain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace GarageWebAPI
{
    public class GarageContext : DbContext
    {
        public DbSet<Garage> Garages { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GarageServerDB"
            );
        }
        public GarageContext(DbContextOptions options) : base(options) { }

        //Vehicles/////////////////////////////////////////////////////////////////////////////////////
        public Vehicle AddVehicle(Vehicle v) 
        {
            Vehicles.Add(v); 
            SaveChanges();

            return v;
        }
        public Vehicle? DeleteVehicle(int id) 
        {
            var v = Vehicles.Find(id);

            if (v != null) { Vehicles.Remove(v); }

            SaveChanges();

            return v;
        }
        public Vehicle? UpdateVehicle(int id ,Vehicle newVehicle) 
        {
            var v = Vehicles.Find(id);

            if (v != null) 
                v.Assign(newVehicle);
            
            SaveChanges();

            return v;
        }
        public List<Vehicle> ReadVehicle() { return Vehicles.ToList(); }

        //Garages//////////////////////////////////////////////////////////////////////////////////////
        //public void AddGarage(Garage g) 
        //{        
        //}
        //public void DeleteGarage() { }
        //public void UpdateGarage() { }
        //public void ReadGarage() { }

        //Workers//////////////////////////////////////////////////////////////////////////////////////
        //public void AddWorker() { }
        //public void DeleteWorker() { }
        //public void UpdateWorker() { }
        //public void ReadWorker() { }

    }
}
