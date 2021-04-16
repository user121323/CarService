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
    public class CarOptionsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarOptionsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarOptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarOptions>>> GetCarOptionsItems()
        {
            return await _context.CarOptionsItems.ToListAsync();
        }

        // GET: api/CarOptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarOptions>> GetCarOptions(long id)
        {
            var carOptions = await _context.CarOptionsItems.FindAsync(id);

            if (carOptions == null)
            {
                return NotFound();
            }

            return carOptions;
        }

        // PUT: api/CarOptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarOptions(long id, CarOptions carOptions)
        {
            if (id != carOptions.Id)
            {
                return BadRequest();
            }

            _context.Entry(carOptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarOptionsExists(id))
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

        // POST: api/CarOptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarOptions>> PostCarOptions(CarOptions carOptions)
        {
            _context.CarOptionsItems.Add(carOptions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarOptions", new { id = carOptions.Id }, carOptions);
        }

        // DELETE: api/CarOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarOptions(long id)
        {
            var carOptions = await _context.CarOptionsItems.FindAsync(id);
            if (carOptions == null)
            {
                return NotFound();
            }

            _context.CarOptionsItems.Remove(carOptions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarOptionsExists(long id)
        {
            return _context.CarOptionsItems.Any(e => e.Id == id);
        }
    }
}
