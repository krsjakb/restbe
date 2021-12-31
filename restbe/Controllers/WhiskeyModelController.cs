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
    public class WhiskeyModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public WhiskeyModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/WhiskeyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhiskeyModel>>> GetWhiskeyModel()
        {
            return await _context.WhiskeyModel
                .Include(c => c.WhiskeyBrand)
                .ToListAsync();
        }

        // GET: api/WhiskeyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WhiskeyModel>> GetWhiskeyModel(int id)
        {
            var whiskeyModel = await _context.WhiskeyModel
                .Include(c => c.WhiskeyBrand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (whiskeyModel == null)
            {
                return NotFound();
            }

            return whiskeyModel;
        }

        // PUT: api/WhiskeyModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWhiskeyModel(int id, WhiskeyModel whiskeyModel)
        {
            if (id != whiskeyModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(whiskeyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WhiskeyModelExists(id))
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

        // POST: api/WhiskeyModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WhiskeyModel>> PostWhiskeyModel(WhiskeyModel whiskeyModel)
        {
            _context.WhiskeyModel.Add(whiskeyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWhiskeyModel", new { id = whiskeyModel.Id }, whiskeyModel);
        }

        // DELETE: api/WhiskeyModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WhiskeyModel>> DeleteWhiskeyModel(int id)
        {
            var whiskeyModel = await _context.WhiskeyModel.FindAsync(id);
            if (whiskeyModel == null)
            {
                return NotFound();
            }

            _context.WhiskeyModel.Remove(whiskeyModel);
            await _context.SaveChangesAsync();

            return whiskeyModel;
        }

        private bool WhiskeyModelExists(int id)
        {
            return _context.WhiskeyModel.Any(e => e.Id == id);
        }
    }
}
