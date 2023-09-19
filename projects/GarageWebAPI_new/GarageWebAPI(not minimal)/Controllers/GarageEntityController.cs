using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;
using GarageWebAPI_not_minimal_.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GarageWebAPI_not_minimal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageEntityController : ControllerBase
    {
        private readonly IRepository<Garage> garageRepository;
        private readonly IRepository<Worker> workerRepository;
        private readonly IRepository<Vehicle> vehicleRepository;
        public GarageEntityController(
            IRepository<Garage> garageRepository,
            IRepository<Worker> workerRepository,
            IRepository<Vehicle> vehicleRepository
            )
        {
            this.garageRepository = garageRepository;
            this.workerRepository = workerRepository;
            this.vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarageEntity>>> GetEntitys()
        {
            var garages = await garageRepository.GetAllAsync();
            var workers = await workerRepository.GetAllAsync();
            var vehicles = await vehicleRepository.GetAllAsync();

            var ge = garages.ToList().ConvertAll(GarageEntity.Convert);
            var we = workers.ToList().ConvertAll(GarageEntity.Convert);
            var ve = vehicles.ToList().ConvertAll(GarageEntity.Convert);

            return Ok(ge.Concat(we).Concat(ve));
        }

        [HttpPost]
        public async Task<ActionResult<GarageEntity>> PostEntity(GarageEntity entity)
        {
            if (entity.IsGarage())
            {
                entity = new GarageEntity(await garageRepository.PostAsync(new Garage(entity)));
            }
            else if (entity.IsVehicle())
            {
                entity = new GarageEntity(await vehicleRepository.PostAsync(new Vehicle(entity)));
            }
            else if (entity.IsWorker())
            {
                entity = new GarageEntity(await workerRepository.PostAsync(new Worker(entity)));
            }
            else
                return BadRequest();
            
            return Ok(entity);
        }
        [HttpPut]
        public async Task<ActionResult<GarageEntity>> PutEntity(GarageEntity entity)
        {
            if (entity.IsGarage())
            {
                entity = new GarageEntity(await garageRepository.PutAsync(new Garage(entity), entity.Id));
               
            }
            else if (entity.IsVehicle())
            {
                entity = new GarageEntity(await vehicleRepository.PutAsync(new Vehicle(entity), entity.Id));
                        
            }
            else if (entity.IsWorker())
            {
                entity = new GarageEntity(await workerRepository.PutAsync(new Worker(entity), entity.Id));
             
            }
            else
                return BadRequest();

            return Ok(entity);
        }
    }
        //[HttpDelete]
        //public ActionResult<GarageEntity> DeleteEntity(GarageEntity entity)
        //{
        //    string item = entity.Type;
        //    int id = entity.Id;

            //    //delete to api/item/id

            //    return //deleted res

            //}
}
