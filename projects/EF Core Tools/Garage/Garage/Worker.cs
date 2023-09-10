namespace Garage
{
    public class Worker
    {
        public string Name { get; set; }
        public int WorkerId { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}