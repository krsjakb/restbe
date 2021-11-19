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
    public class HammersController : ControllerBase
    {
        private readonly MainDbContext _context;

        public HammersController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Hammers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hammer>>> GetHammer()
        {
            return await _context.Hammer.ToListAsync();
        }

        // GET: api/Hammers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hammer>> GetHammer(int id)
        {
            var hammer = await _context.Hammer.FindAsync(id);

            if (hammer == null)
            {
                return NotFound();
            }

            return hammer;
        }

        // PUT: api/Hammers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHammer(int id, Hammer hammer)
        {
            if (id != hammer.Id)
            {
                return BadRequest();
            }

            _context.Entry(hammer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HammerExists(id))
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

        // POST: api/Hammers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hammer>> PostHammer(Hammer hammer)
        {
            _context.Hammer.Add(hammer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHammer", new { id = hammer.Id }, hammer);
        }

        // DELETE: api/Hammers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hammer>> DeleteHammer(int id)
        {
            var hammer = await _context.Hammer.FindAsync(id);
            if (hammer == null)
            {
                return NotFound();
            }

            _context.Hammer.Remove(hammer);
            await _context.SaveChangesAsync();

            return hammer;
        }

        private bool HammerExists(int id)
        {
            return _context.Hammer.Any(e => e.Id == id);
        }
    }
}
