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
    public class MonitorModelController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MonitorModelController(MainDbContext context)
        {
            _context = context;
        }
        // GET: api/MonitorModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonitorModel>>> GetMonitorModel()
        {
            return await _context.MonitorModels
                .Include(c => c.MonitorBrand)
                .ToListAsync();
        }

        // GET: api/MonitorModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonitorModel>> GetMonitorModel(int id)
        {
            var MonitorModel = await _context.MonitorModels
                .Include(c => c.MonitorBrand)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (MonitorModel == null)
            {
                return NotFound();
            }

            return MonitorModel;
        }

        // PUT: api/MonitorModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitorModel(int id, MonitorModel MonitorModel)
        {
            if (id != MonitorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(MonitorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorModelExists(id))
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

        // POST: api/MonitorModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MonitorModel>> PostMonitorModel(MonitorModel MonitorModel)
        {
            _context.MonitorModels.Add(MonitorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitorModel", new { id = MonitorModel.Id }, MonitorModel);
        }

        // DELETE: api/MonitorModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MonitorModel>> DeleteMonitorModel(int id)
        {
            var MonitorModel = await _context.MonitorModels.FindAsync(id);
            if (MonitorModel == null)
            {
                return NotFound();
            }

            _context.MonitorModels.Remove(MonitorModel);
            await _context.SaveChangesAsync();

            return MonitorModel;
        }

        private bool MonitorModelExists(int id)
        {
            return _context.MonitorModels.Any(e => e.Id == id);
        }
    }
}
