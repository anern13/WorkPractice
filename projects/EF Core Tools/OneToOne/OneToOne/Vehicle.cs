using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class Vehicle
    {
        public string Model { get; set; }
        public int Id { get; set; }
        public int? WorkerId { get; set; }
        public Worker? Worker { get; set; }

        public Vehicle(string model) 
        {
            Model = model;
        }
    }
}
