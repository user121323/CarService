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
    public class CarOutsidesController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarOutsidesController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarOutsides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOutsides>>> GetCarOutsideItems()
        {
            return await _context.CarOutsideItems.ToListAsync();
        }

        // GET: api/CarOutsides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarOutsides>> GetCarOutsides(long id)
        {
            var carOutsides = await _context.CarOutsideItems.FindAsync(id);

            if (carOutsides == null)
            {
                return NotFound();
            }

            return carOutsides;
        }

        // PUT: api/CarOutsides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarOutsides(long id, CarOutsides carOutsides)
        {
            if (id != carOutsides.Id)
            {
                return BadRequest();
            }

            _context.Entry(carOutsides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOutsidesExists(id))
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

        // POST: api/CarOutsides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarOutsides>> PostCarOutsides(CarOutsides carOutsides)
        {
            _context.CarOutsideItems.Add(carOutsides);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarOutsides", new { id = carOutsides.Id }, carOutsides);
        }

        // DELETE: api/CarOutsides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarOutsides(long id)
        {
            var carOutsides = await _context.CarOutsideItems.FindAsync(id);
            if (carOutsides == null)
            {
                return NotFound();
            }

            _context.CarOutsideItems.Remove(carOutsides);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarOutsidesExists(long id)
        {
            return _context.CarOutsideItems.Any(e => e.Id == id);
        }
    }
}
