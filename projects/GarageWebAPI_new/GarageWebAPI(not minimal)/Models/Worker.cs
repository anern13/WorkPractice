using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageWebAPI_not_minimal_.DTO;

namespace GarageWebAPI
{
    public class Worker
    {
        public int WorkerId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string? WorkerName { get; set; }

        [JsonIgnore]
        public List<Garage> Garages { get; set; } = new List<Garage>();
        [JsonIgnore]
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public Worker() { }

        public Worker(string _name, int _id)
        {
            WorkerName = _name;
            WorkerId = _id;
        }

        public Worker(GarageEntity ge) : this(ge.Name, ge.Id) { }
    }
}
