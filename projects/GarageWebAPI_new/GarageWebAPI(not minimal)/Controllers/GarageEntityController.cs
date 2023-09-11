using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GarageWebAPI_not_minimal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageEntityController : ControllerBase
    {
        private readonly GarageContext _context;

        public GarageEntityController(GarageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GarageEntity>> GetEntitys() 
        {
            var garages = _context.Garages.ToList().ConvertAll(GarageEntity.Convert);
            var vehicles = _context.Vehicles.ToList().ConvertAll(GarageEntity.Convert);
            var workers = _context.Workers.ToList().ConvertAll(GarageEntity.Convert);

            var entitys = garages.Concat(vehicles).Concat(workers);
            return entitys.ToList();
        }
    }
}
