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
    public class CarCountryOriginsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarCountryOriginsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarCountryOrigins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarCountryOrigin>>> GetCarCountryOriginItems()
        {
            return await _context.CarCountryOriginItems.ToListAsync();
        }

        // GET: api/CarCountryOrigins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarCountryOrigin>> GetCarCountryOrigin(long id)
        {
            var carCountryOrigin = await _context.CarCountryOriginItems.FindAsync(id);

            if (carCountryOrigin == null)
            {
                return NotFound();
            }

            return carCountryOrigin;
        }

        // PUT: api/CarCountryOrigins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarCountryOrigin(long id, CarCountryOrigin carCountryOrigin)
        {
            if (id != carCountryOrigin.Id)
            {
                return BadRequest();
            }

            _context.Entry(carCountryOrigin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarCountryOriginExists(id))
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

        // POST: api/CarCountryOrigins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarCountryOrigin>> PostCarCountryOrigin(CarCountryOrigin carCountryOrigin)
        {
            _context.CarCountryOriginItems.Add(carCountryOrigin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarCountryOrigin", new { id = carCountryOrigin.Id }, carCountryOrigin);
        }

        // DELETE: api/CarCountryOrigins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarCountryOrigin(long id)
        {
            var carCountryOrigin = await _context.CarCountryOriginItems.FindAsync(id);
            if (carCountryOrigin == null)
            {
                return NotFound();
            }

            _context.CarCountryOriginItems.Remove(carCountryOrigin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarCountryOriginExists(long id)
        {
            return _context.CarCountryOriginItems.Any(e => e.Id == id);
        }
    }
}
