using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GarageWebAPI
{
    public class Garage
    {
        [JsonIgnore]
        public List<Worker> Workers { get; set; } = new List<Worker>();
        [JsonIgnore]
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$")]
        public string? Name { get; set; }
        public int GarageId { get; set; }
        
    }
}