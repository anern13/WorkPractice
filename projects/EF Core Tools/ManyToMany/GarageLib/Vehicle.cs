using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLib
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; } = string.Empty;
        //public long PlateNumber { get; set; }
        public int GarageId { get; set; }
        public List<Worker> Workers { get; set; } = new List<Worker>();

        //TODO add validation for platenum not exist in table (added in context)
    }
}
