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
    public class SWCharsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SWCharsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/SWChars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SWChars>>> GetSWChars()
        {
            return await _context.SWChars.ToListAsync();
        }

        // GET: api/SWChars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SWChars>> GetSWChars(int id)
        {
            var SWchars = await _context.SWChars.FindAsync(id);

            if (SWchars == null)
            {
                return NotFound();
            }

            return SWchars;
        }

        // PUT: api/SWChars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSWChars(int id, SWChars SWchars)
        {
            if (id != SWchars.Id)
            {
                return BadRequest();
            }

            _context.Entry(SWchars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SWCharsExists(id))
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

        // POST: api/SWChars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SWChars>> PostSWChars(SWChars SWchars)
        {
            _context.SWChars.Add(SWchars);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSWChars", new { id = SWchars.Id }, SWchars);
        }

        // DELETE: api/SWChars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SWChars>> DeleteSWChars(int id)
        {
            var SWchars = await _context.SWChars.FindAsync(id);
            if (SWchars == null)
            {
                return NotFound();
            }

            _context.SWChars.Remove(SWchars);
            await _context.SaveChangesAsync();

            return SWchars;
        }

        private bool SWCharsExists(int id)
        {
            return _context.SWChars.Any(e => e.Id == id);
        }
    }
}