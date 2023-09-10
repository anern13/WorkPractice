using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLib
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; } = string.Empty;
        public List<Garage> Garages { get; set; } = new List<Garage>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); 
    }
}
