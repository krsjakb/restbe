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
    public class GinBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GinBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/GinBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GinBrands>>> GetGinBrands()
        {
            return await _context.GinBrands
                .Include(c => c.GinModels)
                .ToListAsync();
        }

        // GET: api/GinBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GinBrands>> GetGinBrands(int id)
        {
            var ginBrands = await _context.GinBrands
                .Include(c => c.GinModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (ginBrands == null)
            {
                return NotFound();
            }

            return ginBrands;
        }

        // PUT: api/GinBrands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGinBrands(int id, GinBrands ginBrands)
        {
            if (id != ginBrands.Id)
            {
                return BadRequest();
            }

            _context.Entry(ginBrands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GinBrandsExists(id))
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

        // POST: api/GinBrands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GinBrands>> PostGinBrands(GinBrands ginBrands)
        {
            _context.GinBrands.Add(ginBrands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGinBrands", new { id = ginBrands.Id }, ginBrands);
        }

        // DELETE: api/GinBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GinBrands>> DeleteGinBrands(int id)
        {
            var ginBrands = await _context.GinBrands.FindAsync(id);
            if (ginBrands == null)
            {
                return NotFound();
            }

            _context.GinBrands.Remove(ginBrands);
            await _context.SaveChangesAsync();

            return ginBrands;
        }

        private bool GinBrandsExists(int id)
        {
            return _context.GinBrands.Any(e => e.Id == id);
        }
    }
}
