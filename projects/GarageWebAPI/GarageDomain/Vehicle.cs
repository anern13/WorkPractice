using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageDomain
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; } = string.Empty;
        //public long PlateNumber { get; set; }
        public int? GarageId { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();

        public Vehicle Assign(Vehicle other)
        {
            if (other != null)
            { 
                if (other.Model != string.Empty)
                    Model = other.Model;

                GarageId = other.GarageId;
            }

            return this;
        }
       
    }
}
