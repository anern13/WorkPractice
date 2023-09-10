using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Vehicle
    {
        public int PlateNumber { get; set; } 
        public string Model { get; set; } = string.Empty;
        public int Id { get; set; }
        public int WorkerId { get; set; } 
    }
}
