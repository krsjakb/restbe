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
    public class ELiquidsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ELiquidsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ELiquids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ELiquid>>> GetEliquid()
        {
            return await _context.Eliquid.ToListAsync();
        }

        // GET: api/ELiquids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ELiquid>> GetELiquid(int id)
        {
            var eLiquid = await _context.Eliquid.FindAsync(id);

            if (eLiquid == null)
            {
                return NotFound();
            }

            return eLiquid;
        }

        // PUT: api/ELiquids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutELiquid(int id, ELiquid eLiquid)
        {
            if (id != eLiquid.ID)
            {
                return BadRequest();
            }

            _context.Entry(eLiquid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ELiquidExists(id))
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

        // POST: api/ELiquids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ELiquid>> PostELiquid(ELiquid eLiquid)
        {
            _context.Eliquid.Add(eLiquid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetELiquid", new { id = eLiquid.ID }, eLiquid);
        }

        // DELETE: api/ELiquids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ELiquid>> DeleteELiquid(int id)
        {
            var eLiquid = await _context.Eliquid.FindAsync(id);
            if (eLiquid == null)
            {
                return NotFound();
            }

            _context.Eliquid.Remove(eLiquid);
            await _context.SaveChangesAsync();

            return eLiquid;
        }

        private bool ELiquidExists(int id)
        {
            return _context.Eliquid.Any(e => e.ID == id);
        }
    }
}
