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
    public class RollerShutterModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public RollerShutterModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/RollerShutterModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RollerShutterModel>>> GetRollerShutterModel()
        {
            return await _context.RollerShutterModel.ToListAsync();
        }

        // GET: api/RollerShutterModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RollerShutterModel>> GetRollerShutterModel(int id)
        {
            var rollerShutterModel = await _context.RollerShutterModel.FindAsync(id);

            if (rollerShutterModel == null)
            {
                return NotFound();
            }

            return rollerShutterModel;
        }

        // PUT: api/RollerShutterModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRollerShutterModel(int id, RollerShutterModel rollerShutterModel)
        {
            if (id != rollerShutterModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(rollerShutterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RollerShutterModelExists(id))
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

        // POST: api/RollerShutterModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RollerShutterModel>> PostRollerShutterModel(RollerShutterModel rollerShutterModel)
        {
            _context.RollerShutterModel.Add(rollerShutterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRollerShutterModel", new { id = rollerShutterModel.Id }, rollerShutterModel);
        }

        // DELETE: api/RollerShutterModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RollerShutterModel>> DeleteRollerShutterModel(int id)
        {
            var rollerShutterModel = await _context.RollerShutterModel.FindAsync(id);
            if (rollerShutterModel == null)
            {
                return NotFound();
            }

            _context.RollerShutterModel.Remove(rollerShutterModel);
            await _context.SaveChangesAsync();

            return rollerShutterModel;
        }

        private bool RollerShutterModelExists(int id)
        {
            return _context.RollerShutterModel.Any(e => e.Id == id);
        }
    }
}
