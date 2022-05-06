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
    public class PlugTypesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public PlugTypesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/PlugTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlugType>>> GetPlugTypes()
        {
            return await _context.PlugTypes.ToListAsync();
        }

        // GET: api/PlugTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlugType>> GetPlugType(int id)
        {
            var plugType = await _context.PlugTypes.FindAsync(id);

            if (plugType == null)
            {
                return NotFound();
            }

            return plugType;
        }

        // PUT: api/PlugTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlugType(int id, PlugType plugType)
        {
            if (id != plugType.Id)
            {
                return BadRequest();
            }

            _context.Entry(plugType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlugTypeExists(id))
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

        // POST: api/PlugTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlugType>> PostPlugType(PlugType plugType)
        {
            _context.PlugTypes.Add(plugType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlugType", new { id = plugType.Id }, plugType);
        }

        // DELETE: api/PlugTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlugType>> DeletePlugType(int id)
        {
            var plugType = await _context.PlugTypes.FindAsync(id);
            if (plugType == null)
            {
                return NotFound();
            }

            _context.PlugTypes.Remove(plugType);
            await _context.SaveChangesAsync();

            return plugType;
        }

        private bool PlugTypeExists(int id)
        {
            return _context.PlugTypes.Any(e => e.Id == id);
        }
    }
}
