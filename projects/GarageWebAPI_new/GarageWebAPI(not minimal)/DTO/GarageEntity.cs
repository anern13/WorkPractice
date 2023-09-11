using GarageWebAPI;

namespace GarageWebAPI_not_minimal_.DTO
{
    public class GarageEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        

        public GarageEntity(Garage garage)
        {
            Id = garage.GarageId;
            Name = garage.Name;
            Type = "Garages";
        }
        public GarageEntity(Vehicle vehicle) 
        {
            Id = vehicle.VehicleId;
            Name = vehicle.Model;
            Type = "Vehiclee";
        }

        public GarageEntity(Worker worker)
        {
            Id = worker.WorkerId;
            Name = worker.WorkerName;
            Type = "Workers";
        }

        public static GarageEntity Convert(Garage garage) {  return new GarageEntity(garage);}

        public static GarageEntity Convert(Vehicle vehicle) {  return new GarageEntity(vehicle);}

        public static GarageEntity Convert(Worker worker) {  return new GarageEntity(worker);}
    }
}
