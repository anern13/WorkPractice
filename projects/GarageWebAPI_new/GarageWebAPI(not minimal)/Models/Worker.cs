using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
