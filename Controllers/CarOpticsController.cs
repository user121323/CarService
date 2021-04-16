using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarOpticsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarOpticsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarOptics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOptics>>> GetCarOpticsItems()
        {
            return await _context.CarOpticsItems.ToListAsync();
        }

        // GET: api/CarOptics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarOptics>> GetCarOptics(long id)
        {
            var carOptics = await _context.CarOpticsItems.FindAsync(id);

            if (carOptics == null)
            {
                return NotFound();
            }

            return carOptics;
        }

        // PUT: api/CarOptics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarOptics(long id, CarOptics carOptics)
        {
            if (id != carOptics.Id)
            {
                return BadRequest();
            }

            _context.Entry(carOptics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOpticsExists(id))
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

        // POST: api/CarOptics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarOptics>> PostCarOptics(CarOptics carOptics)
        {
            _context.CarOpticsItems.Add(carOptics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarOptics", new { id = carOptics.Id }, carOptics);
        }

        // DELETE: api/CarOptics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarOptics(long id)
        {
            var carOptics = await _context.CarOpticsItems.FindAsync(id);
            if (carOptics == null)
            {
                return NotFound();
            }

            _context.CarOpticsItems.Remove(carOptics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarOpticsExists(long id)
        {
            return _context.CarOpticsItems.Any(e => e.Id == id);
        }
    }
}
