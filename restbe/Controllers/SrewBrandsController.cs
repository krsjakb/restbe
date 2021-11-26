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
    public class ScrewBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ScrewBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ScrewBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrewBrands>>> GetScrewBrands()
        {
            return await _context.ScrewBrands
                //.Include(c => c.ScrewModels)
                .ToListAsync();
        }

        // GET: api/ScrewBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrewBrands>> GetScrewBrands(int id)
        {
            var screwBrands = await _context.ScrewBrands
                //.Include(c => c.ScrewModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (screwBrands == null)
            {
                return NotFound();
            }

            return screwBrands;
        }

        // PUT: api/ScrewBrands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrewBrands(int id, ScrewBrands screwBrands)
        {
            if (id != screwBrands.Id)
            {
                return BadRequest();
            }

            _context.Entry(screwBrands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrewBrandsExists(id))
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

        // POST: api/ScrewBrands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScrewBrands>> PostScrewBrands(ScrewBrands screwBrands)
        {
            _context.ScrewBrands.Add(screwBrands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrewBrands", new { id = screwBrands.Id }, screwBrands);
        }

        // DELETE: api/ScrewBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScrewBrands>> DeleteScrewBrands(int id)
        {
            var screwBrands = await _context.ScrewBrands.FindAsync(id);
            if (screwBrands == null)
            {
                return NotFound();
            }

            _context.ScrewBrands.Remove(screwBrands);
            await _context.SaveChangesAsync();

            return screwBrands;
        }

        private bool ScrewBrandsExists(int id)
        {
            return _context.ScrewBrands.Any(e => e.Id == id);
        }
    }
}
