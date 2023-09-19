using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageWebAPI_not_minimal_.DTO;

namespace GarageWebAPI
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$")]
        public string? Model { get; set; }
        //nav prop
        public int? GarageId { get; set; }
        [JsonIgnore]
        public List<Worker> Workers { get; set; } = new List<Worker>();

        public Vehicle() { }
        
        public Vehicle(string _model, int _id)
        {
            VehicleId = _id;    
            Model = _model;
        }

        public Vehicle(GarageEntity ge): this(ge.Name, ge.Id) { }
    }
}
