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
    public class CarRegionsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarRegionsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarRegions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarRegion>>> GetCarRegionItems()
        {
            return await _context.CarRegionItems.ToListAsync();
        }

        // GET: api/CarRegions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarRegion>> GetCarRegion(long id)
        {
            var carRegion = await _context.CarRegionItems.FindAsync(id);

            if (carRegion == null)
            {
                return NotFound();
            }

            return carRegion;
        }

        // PUT: api/CarRegions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarRegion(long id, CarRegion carRegion)
        {
            if (id != carRegion.Id)
            {
                return BadRequest();
            }

            _context.Entry(carRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarRegionExists(id))
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

        // POST: api/CarRegions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarRegion>> PostCarRegion(CarRegion carRegion)
        {
            _context.CarRegionItems.Add(carRegion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarRegion", new { id = carRegion.Id }, carRegion);
        }

        // DELETE: api/CarRegions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarRegion(long id)
        {
            var carRegion = await _context.CarRegionItems.FindAsync(id);
            if (carRegion == null)
            {
                return NotFound();
            }

            _context.CarRegionItems.Remove(carRegion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarRegionExists(long id)
        {
            return _context.CarRegionItems.Any(e => e.Id == id);
        }
    }
}
