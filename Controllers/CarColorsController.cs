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
    public class CarColorsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarColorsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarColor>>> GetCarColorItems()
        {
            return await _context.CarColorItems.ToListAsync();
        }

        // GET: api/CarColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarColor>> GetCarColor(long id)
        {
            var carColor = await _context.CarColorItems.FindAsync(id);

            if (carColor == null)
            {
                return NotFound();
            }

            return carColor;
        }

        // PUT: api/CarColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarColor(long id, CarColor carColor)
        {
            if (id != carColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(carColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarColorExists(id))
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

        // POST: api/CarColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarColor>> PostCarColor(CarColor carColor)
        {
            _context.CarColorItems.Add(carColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarColor", new { id = carColor.Id }, carColor);
        }

        // DELETE: api/CarColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarColor(long id)
        {
            var carColor = await _context.CarColorItems.FindAsync(id);
            if (carColor == null)
            {
                return NotFound();
            }

            _context.CarColorItems.Remove(carColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarColorExists(long id)
        {
            return _context.CarColorItems.Any(e => e.Id == id);
        }
    }
}
