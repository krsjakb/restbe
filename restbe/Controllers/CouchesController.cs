using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouchesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public CouchesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Couches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Couch>>> GetCouch()
        {
            return await _context.Couch.ToListAsync();
        }

        // GET: api/Couches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Couch>> GetCouch(int id)
        {
            var couch = await _context.Couch.FindAsync(id);

            if (couch == null)
            {
                return NotFound();
            }

            return couch;
        }

        // PUT: api/Couches/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCouch(int id, Couch couch)
        {
            if (id != couch.Id)
            {
                return BadRequest();
            }

            _context.Entry(couch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CouchExists(id))
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

        // POST: api/Couches
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Couch>> PostCouch(Couch couch)
        {
            _context.Couch.Add(couch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCouch", new { id = couch.Id }, couch);
        }

        // DELETE: api/Couches/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Couch>> DeleteCouch(int id)
        {
            var couch = await _context.Couch.FindAsync(id);
            if (couch == null)
            {
                return NotFound();
            }

            _context.Couch.Remove(couch);
            await _context.SaveChangesAsync();

            return couch;
        }

        private bool CouchExists(int id)
        {
            return _context.Couch.Any(e => e.Id == id);
        }
    }
}
