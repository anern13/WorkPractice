using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class GarageContext:DbContext 
    {
        public DbSet<Worker> Workers {set;get;}
        public DbSet<Vehicle> Vehicles { set;get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GarageDb"
            );
        }
    }

}
