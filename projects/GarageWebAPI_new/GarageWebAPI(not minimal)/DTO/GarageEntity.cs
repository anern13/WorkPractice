using GarageWebAPI;

namespace GarageWebAPI_not_minimal_.DTO
{
    public class GarageEntity
    {
        public int _id;
        public string _name;
        public string _type;
        

        public GarageEntity(Garage garage)
        {
            _id = garage.GarageId;
            _name = garage.Name;
            _type = "garage";
        }
        public GarageEntity(Vehicle vehicle) 
        {
            _id = vehicle.VehicleId;
            _name = vehicle.Model;
            _type = "vehicle";
        }

        public GarageEntity(Worker worker)
        {
            _id = worker.WorkerId;
            _name = worker.WorkerName;
            _type = "worker";
        }

        public static GarageEntity Convert(Garage garage) {  return new GarageEntity(garage);}

        public static GarageEntity Convert(Vehicle vehicle) {  return new GarageEntity(vehicle);}

        public static GarageEntity Convert(Worker worker) {  return new GarageEntity(worker);}
    }
}
