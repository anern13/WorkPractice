namespace GarageLib
{
    public class Garage
    {
        public List<Worker> Workers { get; set; } = new List<Worker>();
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); 

        public string Name { get; set; } = string.Empty;
        public int GarageId { get; set; }

    }
}