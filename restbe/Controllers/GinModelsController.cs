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
    public class GinModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GinModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/GinModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GinModel>>> GetGinModel()
        {
            return await _context.GinModel
                .Include(c => c.GinBrand)
                .ToListAsync();
        }

        // GET: api/GinModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GinModel>> GetGinModel(int id)
        {
            var ginModel = await _context.GinModel
                .Include(c => c.GinBrand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (ginModel == null)
            {
                return NotFound();
            }

            return ginModel;
        }

        // PUT: api/GinModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGinModel(int id, GinModel ginModel)
        {
            if (id != ginModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(ginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GinModelExists(id))
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

        // POST: api/GinModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GinModel>> PostGinModel(GinModel ginModel)
        {
            _context.GinModel.Add(ginModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGinModel", new { id = ginModel.Id }, ginModel);
        }

        // DELETE: api/GinModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GinModel>> DeleteGinModel(int id)
        {
            var ginModel = await _context.GinModel.FindAsync(id);
            if (ginModel == null)
            {
                return NotFound();
            }

            _context.GinModel.Remove(ginModel);
            await _context.SaveChangesAsync();

            return ginModel;
        }

        private bool GinModelExists(int id)
        {
            return _context.GinModel.Any(e => e.Id == id);
        }
    }
}
