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
    public class CarSteeringWheelsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarSteeringWheelsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarSteeringWheels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSteeringWheel>>> GetCarSteeringWheelItems()
        {
            return await _context.CarSteeringWheelItems.ToListAsync();
        }

        // GET: api/CarSteeringWheels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarSteeringWheel>> GetCarSteeringWheel(long id)
        {
            var carSteeringWheel = await _context.CarSteeringWheelItems.FindAsync(id);

            if (carSteeringWheel == null)
            {
                return NotFound();
            }

            return carSteeringWheel;
        }

        // PUT: api/CarSteeringWheels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSteeringWheel(long id, CarSteeringWheel carSteeringWheel)
        {
            if (id != carSteeringWheel.Id)
            {
                return BadRequest();
            }

            _context.Entry(carSteeringWheel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarSteeringWheelExists(id))
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

        // POST: api/CarSteeringWheels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarSteeringWheel>> PostCarSteeringWheel(CarSteeringWheel carSteeringWheel)
        {
            _context.CarSteeringWheelItems.Add(carSteeringWheel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarSteeringWheel", new { id = carSteeringWheel.Id }, carSteeringWheel);
        }

        // DELETE: api/CarSteeringWheels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarSteeringWheel(long id)
        {
            var carSteeringWheel = await _context.CarSteeringWheelItems.FindAsync(id);
            if (carSteeringWheel == null)
            {
                return NotFound();
            }

            _context.CarSteeringWheelItems.Remove(carSteeringWheel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarSteeringWheelExists(long id)
        {
            return _context.CarSteeringWheelItems.Any(e => e.Id == id);
        }
    }
}
