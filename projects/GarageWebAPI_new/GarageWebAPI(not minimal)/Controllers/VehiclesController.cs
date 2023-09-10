using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;

namespace GarageWebAPI_not_minimal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly GarageContext _context;

        public VehiclesController(GarageContext context)
        {
            _context = context;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarageEntity>>> GetVehicles()
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.ToListAsync();
            return Ok(vehicles.ConvertAll(GarageEntity.Convert));
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarageEntity>> GetVehicle(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return new GarageEntity(vehicle);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (_context.Vehicles == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var v = _context.Vehicles.Find(id);
            if (v != null)
            {
                v.Model = vehicle.Model;

                await _context.SaveChangesAsync();

                return Ok(new GarageEntity(v));
            }

            return BadRequest();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GarageEntity>> PostVehicle(Vehicle vehicle)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'GarageContext.Vehicles'  is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return Created("api/Vehicles", new GarageEntity(vehicle));
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{id}/Garage")]
        public ActionResult<GarageEntity?> GetVehicleGarage(int id)
        {
            if (_context.Vehicles == null || _context.Garages == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.Find(id);

            if (vehicle == null)
                return NotFound();

            Garage? garage = null;

            if (vehicle.GarageId != null)
            {
                garage = _context.Garages.Find(vehicle.GarageId);
            }

            return Ok(new GarageEntity(garage));
        }

        [HttpPut("{id}/Garage/{g_id}")]
        public ActionResult<GarageEntity> PutVehicleGarage(int id, int g_id)
        {
            if (_context.Vehicles == null || _context.Garages == null)
            {
                return NotFound();
            }

            var garage = _context.Garages.Find(g_id);
            var vehicle = _context.Vehicles.Find(id);
            
            if(vehicle == null || garage == null)
                return NotFound();

            vehicle.GarageId = g_id;

            _context.SaveChanges();

            return Ok(new GarageEntity(garage));
        }

        [HttpDelete("{id}/Garage")]
        public ActionResult DeleteVehicleGarage(int id)
        {

            if (_context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.Find(id);

            if (vehicle == null)
                return NotFound();

            vehicle.GarageId = null;

            _context.SaveChanges();

            return Ok();
        }

    }
}
