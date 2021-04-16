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
    public class CarEnginesController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarEnginesController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarEngines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarEngine>>> GetCarEngineItems()
        {
            return await _context.CarEngineItems.ToListAsync();
        }

        // GET: api/CarEngines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarEngine>> GetCarEngine(long id)
        {
            var carEngine = await _context.CarEngineItems.FindAsync(id);

            if (carEngine == null)
            {
                return NotFound();
            }

            return carEngine;
        }

        // PUT: api/CarEngines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarEngine(long id, CarEngine carEngine)
        {
            if (id != carEngine.Id)
            {
                return BadRequest();
            }

            _context.Entry(carEngine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarEngineExists(id))
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

        // POST: api/CarEngines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarEngine>> PostCarEngine(CarEngine carEngine)
        {
            _context.CarEngineItems.Add(carEngine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarEngine", new { id = carEngine.Id }, carEngine);
        }

        // DELETE: api/CarEngines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarEngine(long id)
        {
            var carEngine = await _context.CarEngineItems.FindAsync(id);
            if (carEngine == null)
            {
                return NotFound();
            }

            _context.CarEngineItems.Remove(carEngine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarEngineExists(long id)
        {
            return _context.CarEngineItems.Any(e => e.Id == id);
        }
    }
}
