using System.ComponentModel.DataAnnotations;


namespace GarageDomain
{
    public class Garage
    {
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        [RegularExpression(@"^[a-z]",ErrorMessage ="bad input")]//a-z with no white space//not working for now
        [StringLength(25, ErrorMessage = "string exceeding min=2 max=40",MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public int GarageId { get; set; }
        
    }
}