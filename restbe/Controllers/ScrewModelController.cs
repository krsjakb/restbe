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
    public class ScrewModelController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ScrewModelController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ScrewModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrewModel>>> GetScrewModel()
        {
            return await _context.ScrewModel
                //.Include(c => c.ScrewBrand)
                .ToListAsync();
        }

        // GET: api/ScrewModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrewModel>> GetScrewModel(int id)
        {
            var screwModel = await _context.ScrewModel
                //.Include(c => c.ScrewBrand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (screwModel == null)
            {
                return NotFound();
            }

            return screwModel;
        }

        // PUT: api/ScrewModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrewModel(int id, ScrewModel screwModel)
        {
            if (id != screwModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(screwModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrewModelExists(id))
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

        // POST: api/ScrewModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScrewModel>> PostScrewModel(ScrewModel screwModel)
        {
            _context.ScrewModel.Add(screwModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrewModel", new { id = screwModel.Id }, screwModel);
        }

        // DELETE: api/ScrewModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScrewModel>> DeleteScrewModel(int id)
        {
            var screwModel = await _context.ScrewModel.FindAsync(id);
            if (screwModel == null)
            {
                return NotFound();
            }

            _context.ScrewModel.Remove(screwModel);
            await _context.SaveChangesAsync();

            return screwModel;
        }

        private bool ScrewModelExists(int id)
        {
            return _context.ScrewModel.Any(e => e.Id == id);
        }
    }
}
