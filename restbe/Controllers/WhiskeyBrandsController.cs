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
    public class WhiskeyBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public WhiskeyBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/WhiskeyBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhiskeyBrands>>> GetWhiskeyBrands()
        {
            return await _context.WhiskeyBrands
                .Include(c => c.WhiskeyModels)
                .ToListAsync();
        }

        // GET: api/WhiskeyBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WhiskeyBrands>> GetWhiskeyModels(int id)
        {
            var whiskeyBrands = await _context.WhiskeyBrands
                .Include(c => c.WhiskeyModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (whiskeyBrands == null)
            {
                return NotFound();
            }

            return whiskeyBrands;
        }

        // PUT: api/WhiskeyBrands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhiskeyBrands(int id, WhiskeyBrands whiskeyBrands)
        {
            if (id != whiskeyBrands.Id)
            {
                return BadRequest();
            }

            _context.Entry(whiskeyBrands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhiskeyBrandsExists(id))
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

        // POST: api/WhiskeyBrands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WhiskeyBrands>> PostWhiskeyBrands(WhiskeyBrands whiskeyBrands)
        {
            _context.WhiskeyBrands.Add(whiskeyBrands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWhiskeyBrands", new { id = whiskeyBrands.Id }, whiskeyBrands);
        }

        // DELETE: api/WhiskeyBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WhiskeyBrands>> DeleteWhiskeyBrands(int id)
        {
            var whiskeyBrands = await _context.WhiskeyBrands.FindAsync(id);
            if (whiskeyBrands == null)
            {
                return NotFound();
            }

            _context.WhiskeyBrands.Remove(whiskeyBrands);
            await _context.SaveChangesAsync();

            return whiskeyBrands;
        }

        private bool WhiskeyBrandsExists(int id)
        {
            return _context.WhiskeyBrands.Any(e => e.Id == id);
        }
    }
}
