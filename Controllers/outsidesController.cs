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
    public class outsidesController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public outsidesController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/outsides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<outsides>>> GetOutsideItems()
        {
            return await _context.OutsideItems.ToListAsync();
        }

        // GET: api/outsides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<outsides>> Getoutsides(long id)
        {
            var outsides = await _context.OutsideItems.FindAsync(id);

            if (outsides == null)
            {
                return NotFound();
            }

            return outsides;
        }

        // PUT: api/outsides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putoutsides(long id, outsides outsides)
        {
            if (id != outsides.Id)
            {
                return BadRequest();
            }

            _context.Entry(outsides).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!outsidesExists(id))
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

        // POST: api/outsides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<outsides>> Postoutsides(outsides outsides)
        {
            _context.OutsideItems.Add(outsides);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getoutsides", new { id = outsides.Id }, outsides);
        }

        // DELETE: api/outsides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteoutsides(long id)
        {
            var outsides = await _context.OutsideItems.FindAsync(id);
            if (outsides == null)
            {
                return NotFound();
            }

            _context.OutsideItems.Remove(outsides);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool outsidesExists(long id)
        {
            return _context.OutsideItems.Any(e => e.Id == id);
        }
    }
}
