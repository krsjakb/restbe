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
    public class CelloModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public CelloModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/CelloModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CelloModel>>> GetCelloModel()
        {
            return await _context.CelloModel
                .Include(c => c.CelloBrand)
                .ToListAsync();
        }

        // GET: api/CelloModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CelloModel>> GetCelloModel(int id)
        {
            var celloModel = await _context.CelloModel
                .Include(c => c.CelloBrand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (celloModel == null)
            {
                return NotFound();
            }

            return celloModel;
        }

        // PUT: api/CelloModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCelloModel(int id, CelloModel celloModel)
        {
            if (id != celloModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(celloModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CelloModelExists(id))
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

        // POST: api/CelloModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CelloModel>> PostCelloModel(CelloModel celloModel)
        {
            _context.CelloModel.Add(celloModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCelloModel", new { id = celloModel.Id }, celloModel);
        }

        // DELETE: api/CelloModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CelloModel>> DeleteCelloModel(int id)
        {
            var celloModel = await _context.CelloModel.FindAsync(id);
            if (celloModel == null)
            {
                return NotFound();
            }

            _context.CelloModel.Remove(celloModel);
            await _context.SaveChangesAsync();

            return celloModel;
        }

        private bool CelloModelExists(int id)
        {
            return _context.CelloModel.Any(e => e.Id == id);
        }
    }
}
