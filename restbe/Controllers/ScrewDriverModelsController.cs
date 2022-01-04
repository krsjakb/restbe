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
    public class ScrewDriverModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ScrewDriverModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ScrewDriverModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScrewDriverModel>>> GetScrewDriverModel()
        {
            return await _context.ScrewDriverModel
                .ToListAsync();
        }

        // GET: api/ScrewDriverModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScrewDriverModel>> GetScrewDriverModel(int id)
        {
            var ScrewDriverModel = await _context.ScrewDriverModel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (ScrewDriverModel == null)
            {
                return NotFound();
            }

            return ScrewDriverModel;
        }

        // PUT: api/ScrewDriverModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScrewDriverModel(int id, ScrewDriverModel ScrewDriverModel)
        {
            if (id != ScrewDriverModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(ScrewDriverModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScrewDriverModelExists(id))
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

        // POST: api/ScrewDriverModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ScrewDriverModel>> PostScrewDriverModel(ScrewDriverModel ScrewDriverModel)
        {
            _context.ScrewDriverModel.Add(ScrewDriverModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScrewDriverModel", new { id = ScrewDriverModel.Id }, ScrewDriverModel);
        }

        // DELETE: api/ScrewDriverModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ScrewDriverModel>> DeleteScrewDriverModel(int id)
        {
            var ScrewDriverModel = await _context.ScrewDriverModel.FindAsync(id);
            if (ScrewDriverModel == null)
            {
                return NotFound();
            }

            _context.ScrewDriverModel.Remove(ScrewDriverModel);
            await _context.SaveChangesAsync();

            return ScrewDriverModel;
        }

        private bool ScrewDriverModelExists(int id)
        {
            return _context.ScrewDriverModel.Any(e => e.Id == id);
        }
    }
}
