﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GarageWebAPI;
using GarageWebAPI_not_minimal_.DTO;
using GarageWebAPI_not_minimal_.Repos;

namespace GarageWebAPI_not_minimal_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GaragesController : ControllerBase
    {
        private GarageRepository _repo;

        public GaragesController(GarageContext context)
        {
           _repo = new GarageRepository(context);
        }

        // GET: api/Garages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garage>>> GetGarages()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/Garages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Garage>> GetGarage(int id)
        {

            var garage = await _repo.GetByIdAsync(id);

            if (garage == null)
                return NotFound();
            
            return garage;
        }

        // PUT: api/Garages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Garage>> PutGarage(int id, Garage garage)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var g = await _repo.PutAsync(garage, id);
            if (g is not null)
            {
                _repo.SaveChangesAsync();
                return Ok(g);
            }

            return BadRequest();
        }

        // POST: api/Garages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Garage>> PostGarage(Garage garage)
        {
            await _repo.PostAsync(garage);
            _repo.SaveChangesAsync();

            return Created("api/Garages", new GarageEntity(garage));
        }

        // DELETE: api/Garages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Garage>> DeleteGarage(int id)
        {
            var g = await _repo.DeleteAsync(id);
            
            if(g is null)
                return NotFound();

            _repo.SaveChangesAsync();
            return Ok(g);
        }

        //[HttpGet("{id}/Workers")]
        //public ActionResult<IEnumerable<GarageEntity>> GetGarageWorkers(int id)
        //{
        //    if (_context.Garages == null || _context.Workers == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages
        //        .Include(g => g.Workers)
        //        .Where(g => g.GarageId == id).FirstOrDefault();

        //    if (garage == null)
        //        return NotFound();

        //    return Ok(garage.Workers.ConvertAll(GarageEntity.Convert));
        //}

        //[HttpGet("{id}/Vehicles")]
        //public ActionResult<IEnumerable<GarageEntity>> GetGarageVehicles(int id)
        //{
        //    if (_context.Garages == null || _context.Vehicles == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages
        //        .Include(g => g.Vehicles)
        //        .Where(g => g.GarageId == id).FirstOrDefault();

        //    if (garage == null)
        //        return NotFound();

        //    return Ok(garage.Vehicles.ConvertAll(GarageEntity.Convert));
        //}

        //[HttpPut("{id}/Workers/{w_id}")]
        //public ActionResult<GarageEntity> PutGarageWorker(int id, int w_id)
        //{
        //    if (_context.Workers == null || _context.Garages == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages.FirstOrDefault(g => g.GarageId == id);
        //    var worker = _context.Workers.FirstOrDefault(w => w.WorkerId == w_id);

        //    if (worker == null || garage == null)
        //        return NotFound();

        //    garage.Workers.Add(worker);

        //    _context.SaveChanges();

        //    return Ok(new GarageEntity(worker));
        //}

        //[HttpPut("{id}/Vehicles/{v_id}")]
        //public ActionResult<GarageEntity> PutGarageVehicle(int id, int v_id)
        //{
        //    if (_context.Vehicles == null || _context.Garages == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages.FirstOrDefault(g => g.GarageId == id);
        //    var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == v_id);

        //    if (vehicle == null || garage == null)
        //        return NotFound();

        //    garage.Vehicles.Add(vehicle);

        //    _context.SaveChanges();

        //    return Ok(new GarageEntity(vehicle));
        //}

        //[HttpDelete("{id}/Workers/{w_id}")]
        //public ActionResult DeleteGarageWorker(int id, int w_id)
        //{
        //    if (_context.Workers == null || _context.Garages == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages
        //        .Include(g => g.Workers)
        //        .FirstOrDefault(g => g.GarageId == id);

        //    var worker = _context.Workers.FirstOrDefault(w => w.WorkerId == w_id);

        //    if (worker == null || garage == null)
        //        return NotFound();

        //    garage.Workers.Remove(worker);

        //    _context.SaveChanges();

        //    return Ok();
        //}

        //[HttpDelete("{id}/Vehicles/{v_id}")]
        //public ActionResult DeleteGarageVehicle(int id, int v_id)
        //{
        //    if (_context.Vehicles == null || _context.Garages == null)
        //    {
        //        return NotFound();
        //    }

        //    var garage = _context.Garages
        //        .Include(g => g.Vehicles)
        //        .FirstOrDefault(g => g.GarageId == id);

        //    var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == v_id);

        //    if (vehicle == null || garage == null)
        //        return NotFound();

        //    garage.Vehicles.Remove(vehicle);

        //    _context.SaveChanges();

        //    return Ok();

        //}
    }
}
