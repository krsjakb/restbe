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
    public class MonitorBrandController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MonitorBrandController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/MonitorBrand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitorBrand>>> GetMonitorBrand()
        {
            return await _context.MonitorBrands
                .Include(c => c.MonitorModels)
                .ToListAsync();
        }

        // GET: api/MonitorBrand/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonitorBrand>> GetMonitorBrand(int id)
        {
            var MonitorBrand = await _context.MonitorBrands
                .Include(c => c.MonitorModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (MonitorBrand == null)
            {
                return NotFound();
            }

            return MonitorBrand;
        }

        // PUT: api/MonitorBrand/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitorBrand(int id, MonitorBrand MonitorBrand)
        {
            if (id != MonitorBrand.Id)
            {
                return BadRequest();
            }

            _context.Entry(MonitorBrand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorBrandExists(id))
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

        // POST: api/MonitorBrand
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MonitorBrand>> PostMonitorBrand(MonitorBrand MonitorBrand)
        {
            _context.MonitorBrands.Add(MonitorBrand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitorBrand", new { id = MonitorBrand.Id }, MonitorBrand);
        }

        // DELETE: api/MonitorBrand/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonitorBrand>> DeleteMonitorBrand(int id)
        {
            var MonitorBrand = await _context.MonitorBrands.FindAsync(id);
            if (MonitorBrand == null)
            {
                return NotFound();
            }

            _context.MonitorBrands.Remove(MonitorBrand);
            await _context.SaveChangesAsync();

            return MonitorBrand;
        }

        private bool MonitorBrandExists(int id)
        {
            return _context.MonitorBrands.Any(e => e.Id == id);
        }
    }
}
