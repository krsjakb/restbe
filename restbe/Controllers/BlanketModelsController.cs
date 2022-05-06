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
    public class BlanketModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public BlanketModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/BlanketModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlanketModel>>> GetBlanketModel()
        {
            return await _context.BlanketModel.ToListAsync();
        }

        // GET: api/BlanketModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlanketModel>> GetBlanketModel(int id)
        {
            var blanketModel = await _context.BlanketModel.FindAsync(id);

            if (blanketModel == null)
            {
                return NotFound();
            }

            return blanketModel;
        }

        // PUT: api/BlanketModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlanketModel(int id, BlanketModel blanketModel)
        {
            if (id != blanketModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(blanketModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlanketModelExists(id))
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

        // POST: api/BlanketModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BlanketModel>> PostBlanketModel(BlanketModel blanketModel)
        {
            _context.BlanketModel.Add(blanketModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlanketModel", new { id = blanketModel.Id }, blanketModel);
        }

        // DELETE: api/BlanketModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlanketModel>> DeleteBlanketModel(int id)
        {
            var blanketModel = await _context.BlanketModel.FindAsync(id);
            if (blanketModel == null)
            {
                return NotFound();
            }

            _context.BlanketModel.Remove(blanketModel);
            await _context.SaveChangesAsync();

            return blanketModel;
        }

        private bool BlanketModelExists(int id)
        {
            return _context.BlanketModel.Any(e => e.Id == id);
        }
    }
}
