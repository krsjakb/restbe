using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restbe.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OSController : ControllerBase
    {
        private readonly MainDbContext _context;

        public OSController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OperatingSystem>>> GetOS()
        {
            return await _context.Os.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperatingSystem>> GetOs(int id)
        {
            var os = await _context.Os.FirstOrDefaultAsync(c => c.Id == id);

            if (os == null)
            {
                return NotFound();
            }

            return os;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOS(int id, OperatingSystem os)
        {
            if (id != os.Id)
            {
                return BadRequest();
            }

            _context.Entry(os).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsExists(id))
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

        [HttpPost]
        public async Task<ActionResult<OperatingSystem>> PostOs(OperatingSystem os)
        {
            _context.Os.Add(os);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOs", new { id = os.Id }, os);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OperatingSystem>> DeleteOs(int id)
        {
            var os = await _context.Os.FindAsync(id);
            if (os == null)
            {
                return NotFound();
            }

            _context.Os.Remove(os);
            await _context.SaveChangesAsync();

            return os;
        }

        private bool OsExists(int id)
        {
            return _context.Os.Any(e => e.Id == id);
        }
    }
}
