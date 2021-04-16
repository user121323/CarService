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
    public class CarBodiesController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarBodiesController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarBodies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarBody>>> GetCarBodyItems()
        {
            return await _context.CarBodyItems.ToListAsync();
        }

        // GET: api/CarBodies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarBody>> GetCarBody(long id)
        {
            var carBody = await _context.CarBodyItems.FindAsync(id);

            if (carBody == null)
            {
                return NotFound();
            }

            return carBody;
        }

        // PUT: api/CarBodies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarBody(long id, CarBody carBody)
        {
            if (id != carBody.Id)
            {
                return BadRequest();
            }

            _context.Entry(carBody).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBodyExists(id))
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

        // POST: api/CarBodies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarBody>> PostCarBody(CarBody carBody)
        {
            _context.CarBodyItems.Add(carBody);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarBody", new { id = carBody.Id }, carBody);
        }

        // DELETE: api/CarBodies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarBody(long id)
        {
            var carBody = await _context.CarBodyItems.FindAsync(id);
            if (carBody == null)
            {
                return NotFound();
            }

            _context.CarBodyItems.Remove(carBody);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarBodyExists(long id)
        {
            return _context.CarBodyItems.Any(e => e.Id == id);
        }
    }
}
