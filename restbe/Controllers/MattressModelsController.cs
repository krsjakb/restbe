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
    public class MattressModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MattressModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/MattressModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MattressModel>>> GetMattressModel()
        {
            return await _context.MattressModel.ToListAsync();
        }

        // GET: api/MattressModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MattressModel>> GetMattressModel(int id)
        {
            var mattressModel = await _context.MattressModel.FindAsync(id);

            if (mattressModel == null)
            {
                return NotFound();
            }

            return mattressModel;
        }

        // PUT: api/MattressModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMattressModel(int id, MattressModel mattressModel)
        {
            if (id != mattressModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(mattressModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MattressModelExists(id))
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

        // POST: api/MattressModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MattressModel>> PostMattressModel(MattressModel mattressModel)
        {
            _context.MattressModel.Add(mattressModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMattressModel", new { id = mattressModel.Id }, mattressModel);
        }

        // DELETE: api/MattressModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MattressModel>> DeleteMattressModel(int id)
        {
            var mattressModel = await _context.MattressModel.FindAsync(id);
            if (mattressModel == null)
            {
                return NotFound();
            }

            _context.MattressModel.Remove(mattressModel);
            await _context.SaveChangesAsync();

            return mattressModel;
        }

        private bool MattressModelExists(int id)
        {
            return _context.MattressModel.Any(e => e.Id == id);
        }
    }
}
