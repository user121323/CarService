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
    public class CarDrivesController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarDrivesController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarDrives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDrive>>> GetCarDriveItems()
        {
            return await _context.CarDriveItems.ToListAsync();
        }

        // GET: api/CarDrives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDrive>> GetCarDrive(long id)
        {
            var carDrive = await _context.CarDriveItems.FindAsync(id);

            if (carDrive == null)
            {
                return NotFound();
            }

            return carDrive;
        }

        // PUT: api/CarDrives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarDrive(long id, CarDrive carDrive)
        {
            if (id != carDrive.Id)
            {
                return BadRequest();
            }

            _context.Entry(carDrive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDriveExists(id))
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

        // POST: api/CarDrives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarDrive>> PostCarDrive(CarDrive carDrive)
        {
            _context.CarDriveItems.Add(carDrive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarDrive", new { id = carDrive.Id }, carDrive);
        }

        // DELETE: api/CarDrives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarDrive(long id)
        {
            var carDrive = await _context.CarDriveItems.FindAsync(id);
            if (carDrive == null)
            {
                return NotFound();
            }

            _context.CarDriveItems.Remove(carDrive);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarDriveExists(long id)
        {
            return _context.CarDriveItems.Any(e => e.Id == id);
        }
    }
}
