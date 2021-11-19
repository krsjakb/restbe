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
    public class CelloBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public CelloBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/CelloBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CelloBrands>>> GetCelloBrands()
        {
            return await _context.CelloBrands
                .Include(c => c.CelloModels)
                .ToListAsync();
        }

        // GET: api/CelloBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CelloBrands>> GetCelloBrands(int id)
        {
            var celloBrands = await _context.CelloBrands
                .Include(c => c.CelloModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (celloBrands == null)
            {
                return NotFound();
            }

            return celloBrands;
        }

        // PUT: api/CelloBrands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelloBrands(int id, CelloBrands celloBrands)
        {
            if (id != celloBrands.Id)
            {
                return BadRequest();
            }

            _context.Entry(celloBrands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelloBrandsExists(id))
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

        // POST: api/CelloBrands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CelloBrands>> PostCelloBrands(CelloBrands celloBrands)
        {
            _context.CelloBrands.Add(celloBrands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelloBrands", new { id = celloBrands.Id }, celloBrands);
        }

        // DELETE: api/CelloBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CelloBrands>> DeleteCelloBrands(int id)
        {
            var celloBrands = await _context.CelloBrands.FindAsync(id);
            if (celloBrands == null)
            {
                return NotFound();
            }

            _context.CelloBrands.Remove(celloBrands);
            await _context.SaveChangesAsync();

            return celloBrands;
        }

        private bool CelloBrandsExists(int id)
        {
            return _context.CelloBrands.Any(e => e.Id == id);
        }
    }
}
