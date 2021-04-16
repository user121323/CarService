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
    public class CarSparePartsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarSparePartsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarSpareParts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSpareParts>>> GetCarSparePartsItems()
        {
            return await _context.CarSparePartsItems.ToListAsync();
        }

        // GET: api/CarSpareParts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarSpareParts>> GetCarSpareParts(long id)
        {
            var carSpareParts = await _context.CarSparePartsItems.FindAsync(id);

            if (carSpareParts == null)
            {
                return NotFound();
            }

            return carSpareParts;
        }

        // PUT: api/CarSpareParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSpareParts(long id, CarSpareParts carSpareParts)
        {
            if (id != carSpareParts.Id)
            {
                return BadRequest();
            }

            _context.Entry(carSpareParts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarSparePartsExists(id))
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

        // POST: api/CarSpareParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarSpareParts>> PostCarSpareParts(CarSpareParts carSpareParts)
        {
            _context.CarSparePartsItems.Add(carSpareParts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarSpareParts", new { id = carSpareParts.Id }, carSpareParts);
        }

        // DELETE: api/CarSpareParts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarSpareParts(long id)
        {
            var carSpareParts = await _context.CarSparePartsItems.FindAsync(id);
            if (carSpareParts == null)
            {
                return NotFound();
            }

            _context.CarSparePartsItems.Remove(carSpareParts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarSparePartsExists(long id)
        {
            return _context.CarSparePartsItems.Any(e => e.Id == id);
        }
    }
}
