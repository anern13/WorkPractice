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
    public class WorkersController : ControllerBase
    {
        private readonly GarageContext _context;

        public WorkersController(GarageContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GarageEntity>>> GetWorkers()
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var workers = await _context.Workers.ToListAsync();

            return Ok(workers.ConvertAll(GarageEntity.Convert));
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GarageEntity>> GetWorker(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return new GarageEntity(worker);
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorker(int id, Worker worker)
        {
            if (id != worker.WorkerId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Entry(worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GarageEntity>> PostWorker(Worker worker)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'GarageContext.Workers'  is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            return Created("api/Workers", new GarageEntity(worker));
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkerExists(int id)
        {
            return (_context.Workers?.Any(e => e.WorkerId == id)).GetValueOrDefault();
        }

        [HttpGet("{id}/Garages")]
        public ActionResult<IEnumerable<GarageEntity>> GetWorkerGarages(int id)
        {
            if (_context.Workers == null)
            {
                return NotFound();
            }

            var worker = _context.Workers
                .Include(w => w.Garages)
                .Where(w => w.WorkerId == id)
                .FirstOrDefault();

            if (worker == null)
            {
                return NotFound();
            }
            return worker.Garages.ConvertAll(GarageEntity.Convert);

        }


        //[HttpPost("{id}/Garages")]
        //public ActionResult<Garage> PutWorkerGarages(int id, Garage garage)


        [HttpPut("{id}/Garages/{g_id}")]
        public ActionResult<GarageEntity> PutWorkerGarages(int id, int g_id)
        {
            if (_context.Workers == null || _context.Garages == null)
            {
                return NotFound();
            }

            var garage = _context.Garages.FirstOrDefault(g => g.GarageId == g_id);
            var worker = _context.Workers.FirstOrDefault(w => w.WorkerId == id);
            
            if (worker == null || garage == null)
                return NotFound();

            worker.Garages.Add(garage);

            _context.SaveChanges();

            return Ok(new GarageEntity(garage));
        }

        [HttpDelete("{id}/Garages/{g_id}")]
        public ActionResult<GarageEntity> DeleteWorkerGarages(int id, int g_id)
        {
            if (_context.Workers == null || _context.Garages == null)
            {
                return NotFound();
            }

            var garage = _context.Garages.FirstOrDefault(g => g.GarageId == g_id);
            var worker = _context.Workers
                .Include(w => w.Garages)
                .FirstOrDefault(w => w.WorkerId == id);

            if (worker == null || garage == null)
                return NotFound();

            worker.Garages.Remove(garage);

            _context.SaveChanges();

            return Ok(new GarageEntity(garage));
        }
    }
}
