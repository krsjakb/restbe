using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restbe.Models;

namespace restbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LampsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public LampsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Lamps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lamp>>> GetLamps()
        {
            return await _context.Lamps.ToListAsync();
        }

        // GET: api/Lamps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lamp>> GetLamp(int id)
        {
            var lamp = await _context.Lamps.FindAsync(id);

            if (lamp == null)
            {
                return NotFound();
            }

            return lamp;
        }

        // PUT: api/Lamps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLamp(int id, Lamp lamp)
        {
            if (id != lamp.Id)
            {
                return BadRequest();
            }

            _context.Entry(lamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LampExists(id))
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

        // POST: api/Lamps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Lamp>> PostLamp(Lamp lamp)
        {
            _context.Lamps.Add(lamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLamp", new { id = lamp.Id }, lamp);
        }

        // DELETE: api/Lamps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lamp>> DeleteLamp(int id)
        {
            var lamp = await _context.Lamps.FindAsync(id);
            if (lamp == null)
            {
                return NotFound();
            }

            _context.Lamps.Remove(lamp);
            await _context.SaveChangesAsync();

            return lamp;
        }

        private bool LampExists(int id)
        {
            return _context.Lamps.Any(e => e.Id == id);
        }
    }
}
