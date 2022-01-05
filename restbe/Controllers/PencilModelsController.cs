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
    public class PencilModelController : ControllerBase
    {
        private readonly MainDbContext _context;

        public PencilModelController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/PencilModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PencilModel>>> GetPencilModel()
        {
            return await _context.PencilModel
                .ToListAsync();
        }

        // GET: api/PencilModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PencilModel>> GetPencilModel(int id)
        {
            var PencilModel = await _context.PencilModel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (PencilModel == null)
            {
                return NotFound();
            }

            return PencilModel;
        }

        // PUT: api/PencilModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPencilModel(int id, PencilModel PencilModel)
        {
            if (id != PencilModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(PencilModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PencilModelExists(id))
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

        // POST: api/PencilModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PencilModel>> PostPencilModel(PencilModel PencilModel)
        {
            _context.PencilModel.Add(PencilModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPencilModel", new { id = PencilModel.Id }, PencilModel);
        }

        // DELETE: api/PencilModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PencilModel>> DeletePencilModel(int id)
        {
            var PencilModel = await _context.PencilModel.FindAsync(id);
            if (PencilModel == null)
            {
                return NotFound();
            }

            _context.PencilModel.Remove(PencilModel);
            await _context.SaveChangesAsync();

            return PencilModel;
        }

        private bool PencilModelExists(int id)
        {
            return _context.PencilModel.Any(e => e.Id == id);
        }
    }
}