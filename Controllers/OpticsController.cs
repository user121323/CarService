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
    public class OpticsController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public OpticsController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/Optics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Optics>>> GetOpticsItems()
        {
            return await _context.OpticsItems.ToListAsync();
        }

        // GET: api/Optics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Optics>> GetOptics(long id)
        {
            var optics = await _context.OpticsItems.FindAsync(id);

            if (optics == null)
            {
                return NotFound();
            }

            return optics;
        }

        // PUT: api/Optics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptics(long id, Optics optics)
        {
            if (id != optics.Id)
            {
                return BadRequest();
            }

            _context.Entry(optics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpticsExists(id))
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

        // POST: api/Optics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Optics>> PostOptics(Optics optics)
        {
            _context.OpticsItems.Add(optics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptics", new { id = optics.Id }, optics);
        }

        // DELETE: api/Optics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptics(long id)
        {
            var optics = await _context.OpticsItems.FindAsync(id);
            if (optics == null)
            {
                return NotFound();
            }

            _context.OpticsItems.Remove(optics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OpticsExists(long id)
        {
            return _context.OpticsItems.Any(e => e.Id == id);
        }
    }
}
