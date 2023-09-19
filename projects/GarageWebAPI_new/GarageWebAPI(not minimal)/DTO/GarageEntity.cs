using GarageWebAPI;

namespace GarageWebAPI_not_minimal_.DTO
{
    public class GarageEntity
    {
        const string _garage = "Garages";
        const string _vehicle = "Vehicles";
        const string _worker = "Workers";

        public string Type { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        
        public GarageEntity() { }

        public GarageEntity(Garage garage)
        {
            Id = garage.GarageId;
            Name = garage.Name;
            Type = _garage;
        }
        public GarageEntity(Vehicle vehicle) 
        {
            Id = vehicle.VehicleId;
            Name = vehicle.Model;
            Type = _vehicle;
        }

        public GarageEntity(Worker worker)
        {
            Id = worker.WorkerId;
            Name = worker.WorkerName;
            Type = _worker;
        }

        public static GarageEntity Convert(Garage garage) {  return new GarageEntity(garage);}

        public static GarageEntity Convert(Vehicle vehicle) {  return new GarageEntity(vehicle);}

        public static GarageEntity Convert(Worker worker) {  return new GarageEntity(worker);}

        public bool IsWorker()
        {
            return (Type == _worker);
        }

        public bool IsGarage()
        {
            return (Type == _garage);
        }

        public bool IsVehicle()
        {
            return (Type == _vehicle);
        }
    }
}
