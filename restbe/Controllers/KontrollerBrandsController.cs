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
    public class KontrollerBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public KontrollerBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/KontrollerModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KontrollerBrands>>> GetKontrollerModel()
        {
            return await _context.KontrollerModel
                .ToListAsync();
        }

        // GET: api/KontrollerModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KontrollerBrands>> GetKontrollerModel(int id)
        {
            var KontrollerModel = await _context.KontrollerModel
                .FirstOrDefaultAsync(c => c.Id == id);

            if (KontrollerModel == null)
            {
                return NotFound();
            }

            return KontrollerModel;
        }

        // PUT: api/KontrollerModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKontrollerModel(int id, KontrollerBrands KontrollerModel)
        {
            if (id != KontrollerModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(KontrollerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontrollerModelExists(id))
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

        // POST: api/KontrollerModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<KontrollerBrands>> PostKontrollerModel(KontrollerBrands KontrollerModel)
        {
            _context.KontrollerModel.Add(KontrollerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKontrollerModel", new { id = KontrollerModel.Id }, KontrollerModel);
        }

        // DELETE: api/KontrollerModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KontrollerBrands>> DeleteKontrollerModel(int id)
        {
            var KontrollerModel = await _context.KontrollerModel.FindAsync(id);
            if (KontrollerModel == null)
            {
                return NotFound();
            }

            _context.KontrollerModel.Remove(KontrollerModel);
            await _context.SaveChangesAsync();

            return KontrollerModel;
        }

        private bool KontrollerModelExists(int id)
        {
            return _context.KontrollerModel.Any(e => e.Id == id);
        }
    }
}
