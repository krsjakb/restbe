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
    public class ChairModelController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ChairModelController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Chairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChairModel>>> GetChairModel()
        {
            return await _context.ChairModel
                .ToListAsync();
        }

        // GET: api/Chairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChairModel>> GetChairModel(int id)
        {
            var ChairModel= await _context.ChairModel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (ChairModel== null)
            {
                return NotFound();
            }

            return ChairModel;
        }

        // PUT: api/Chairs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChairModel(int id, ChairModel ChairModel)
        {
            if (id != ChairModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(ChairModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChairModelExists(id))
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

        // POST: api/Chairs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ChairModel>> PostChairModel(ChairModel ChairModel)
        {
            _context.ChairModel.Add(ChairModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChairModel", new { id = ChairModel.Id }, ChairModel);
        }

        // DELETE: api/Chairs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ChairModel>> DeleteChairModel(int id)
        {
            var ChairModel= await _context.ChairModel.FindAsync(id);
            if (ChairModel== null)
            {
                return NotFound();
            }

            _context.ChairModel.Remove(ChairModel);
            await _context.SaveChangesAsync();

            return ChairModel;
        }

        private bool ChairModelExists(int id)
        {
            return _context.ChairModel.Any(e => e.Id == id);
        }
    }
}