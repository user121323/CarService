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
    public class CarMediasController : ControllerBase
    {
        private readonly CarServiceContext _context;

        public CarMediasController(CarServiceContext context)
        {
            _context = context;
        }

        // GET: api/CarMedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarMedia>>> GetCarMediaItems()
        {
            return await _context.CarMediaItems.ToListAsync();
        }

        // GET: api/CarMedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarMedia>> GetCarMedia(long id)
        {
            var carMedia = await _context.CarMediaItems.FindAsync(id);

            if (carMedia == null)
            {
                return NotFound();
            }

            return carMedia;
        }

        // PUT: api/CarMedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarMedia(long id, CarMedia carMedia)
        {
            if (id != carMedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(carMedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMediaExists(id))
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

        // POST: api/CarMedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarMedia>> PostCarMedia(CarMedia carMedia)
        {
            _context.CarMediaItems.Add(carMedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarMedia", new { id = carMedia.Id }, carMedia);
        }

        // DELETE: api/CarMedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarMedia(long id)
        {
            var carMedia = await _context.CarMediaItems.FindAsync(id);
            if (carMedia == null)
            {
                return NotFound();
            }

            _context.CarMediaItems.Remove(carMedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarMediaExists(long id)
        {
            return _context.CarMediaItems.Any(e => e.Id == id);
        }
    }
}
