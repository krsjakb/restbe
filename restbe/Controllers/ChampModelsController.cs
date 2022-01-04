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
    public class ChampModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ChampModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ChampModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChampModel>>> GetChampModel()
        {
            return await _context.ChampModel
                .ToListAsync();
        }

        // GET: api/ChampModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChampModel>> GetChampModel(int id)
        {
            var champModel = await _context.ChampModel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (champModel == null)
            {
                return NotFound();
            }

            return champModel;
        }

        // PUT: api/ChampModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampModel(int id, ChampModel champModel)
        {
            if (id != champModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(champModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampModelExists(id))
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

        // POST: api/ChampModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChampModel>> PostChampModel(ChampModel champModel)
        {
            _context.ChampModel.Add(champModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChampModel", new { id = champModel.Id }, champModel);
        }

        // DELETE: api/ChampModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChampModel>> DeleteChampModel(int id)
        {
            var champModel = await _context.ChampModel.FindAsync(id);
            if (champModel == null)
            {
                return NotFound();
            }

            _context.ChampModel.Remove(champModel);
            await _context.SaveChangesAsync();

            return champModel;
        }

        private bool ChampModelExists(int id)
        {
            return _context.ChampModel.Any(e => e.Id == id);
        }
    }
}
