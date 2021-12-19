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
    public class USBConnectorsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public USBConnectorsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/USBConnectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<USBConnector>>> GetUSBConnector()
        {
            return await _context.USBConnector.Include(e => e.PhoneCompatibility)
                                              .ToListAsync();
        }

        // GET: api/USBConnectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<USBConnector>> GetUSBConnector(int id)
        {
            var uSBConnector = await _context.USBConnector.Include(e => e.PhoneCompatibility)
                                                          .FirstOrDefaultAsync(e => e.Id == id);
            

            if (uSBConnector == null)
            {
                return NotFound();
            }

            return uSBConnector;
        }

        // PUT: api/USBConnectors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUSBConnector(int id, USBConnector uSBConnector)
        {
            if (id != uSBConnector.Id)
            {
                return BadRequest();
            }

            _context.Entry(uSBConnector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USBConnectorExists(id))
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

        // POST: api/USBConnectors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<USBConnector>> PostUSBConnector(USBConnector uSBConnector)
        {
            _context.USBConnector.Add(uSBConnector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUSBConnector", new { id = uSBConnector.Id }, uSBConnector);
        }

        // DELETE: api/USBConnectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<USBConnector>> DeleteUSBConnector(int id)
        {
            var uSBConnector = await _context.USBConnector.FindAsync(id);
            if (uSBConnector == null)
            {
                return NotFound();
            }

            _context.USBConnector.Remove(uSBConnector);
            await _context.SaveChangesAsync();

            return uSBConnector;
        }

        private bool USBConnectorExists(int id)
        {
            return _context.USBConnector.Any(e => e.Id == id);
        }
    }
}
