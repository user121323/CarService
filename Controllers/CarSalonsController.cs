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
    public class CarSalonsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarSalonsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarSalons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSalon>>> GetCarSalonItems()
        {
            return await _context.CarSalonItems.ToListAsync();
        }

        // GET: api/CarSalons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarSalon>> GetCarSalon(long id)
        {
            var carSalon = await _context.CarSalonItems.FindAsync(id);

            if (carSalon == null)
            {
                return NotFound();
            }

            return carSalon;
        }

        // PUT: api/CarSalons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSalon(long id, CarSalon carSalon)
        {
            if (id != carSalon.Id)
            {
                return BadRequest();
            }

            _context.Entry(carSalon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarSalonExists(id))
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

        // POST: api/CarSalons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarSalon>> PostCarSalon(CarSalon carSalon)
        {
            _context.CarSalonItems.Add(carSalon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarSalon", new { id = carSalon.Id }, carSalon);
        }

        // DELETE: api/CarSalons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarSalon(long id)
        {
            var carSalon = await _context.CarSalonItems.FindAsync(id);
            if (carSalon == null)
            {
                return NotFound();
            }

            _context.CarSalonItems.Remove(carSalon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarSalonExists(long id)
        {
            return _context.CarSalonItems.Any(e => e.Id == id);
        }
    }
}
