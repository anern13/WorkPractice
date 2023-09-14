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
        private GarageEntityRepository _repo;

        //public GarageEntityController(GarageContext context)
        //{
        //    List<IRepository> repositories;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<GarageEntity>> GetEntitys()
        //{
        //    var garages = _context.Garages.ToList().ConvertAll(GarageEntity.Convert);
        //    var vehicles = _context.Vehicles.ToList().ConvertAll(GarageEntity.Convert);
        //    var workers = _context.Workers.ToList().ConvertAll(GarageEntity.Convert);

        //    var entitys = garages.Concat(vehicles).Concat(workers);
        //    return entitys.ToList();
        //}

        //[HttpPost]
        //public ActionResult<GarageEntity> PostEntity(GarageEntity entity)
        //{
        //    string item = entity.Type;

        //    //post to api/item (garage entity)

        //    return; //new res
        //}
        //[HttpPut]
        //public ActionResult<GarageEntity> PutEntity(GarageEntity entity)
        //{
        //    string item = entity.Type;
        //    int id = entity.Id;

        //    //put to api/item/id(garage entity)

        //    return //updated res

        //}
        //[HttpDelete]
        //public ActionResult<GarageEntity> DeleteEntity(GarageEntity entity)
        //{
        //    string item = entity.Type;
        //    int id = entity.Id;

        //    //delete to api/item/id

        //    return //deleted res

      //  }
    }
}
