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
    public class PhoneUSBCompatibilitiesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public PhoneUSBCompatibilitiesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/PhoneUSBCompatibilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneUSBCompatibility>>> GetPhone2USBConnector()
        {
            return await _context.PhoneUSBCompatibility.Include(e => e.Phone)
                                                       .Include(e => e.USBConnector)
                                                       .ToListAsync();
        }

        // GET: api/PhoneUSBCompatibilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneUSBCompatibility>> GetPhoneUSBCompatibility(int id)
        {
            var phoneUSBCompatibility = await _context.PhoneUSBCompatibility.Include(e => e.Phone)
                                                                            .Include(e => e.USBConnector)
                                                                            .FirstOrDefaultAsync(e => e.Id == id);

            if (phoneUSBCompatibility == null)
            {
                return NotFound();
            }

            return phoneUSBCompatibility;
        }

        // PUT: api/PhoneUSBCompatibilities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneUSBCompatibility(int id, PhoneUSBCompatibility phoneUSBCompatibility)
        {
            if (id != phoneUSBCompatibility.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneUSBCompatibility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneUSBCompatibilityExists(id))
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

        // POST: api/PhoneUSBCompatibilities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhoneUSBCompatibility>> PostPhoneUSBCompatibility(PhoneUSBCompatibility phoneUSBCompatibility)
        {
            _context.PhoneUSBCompatibility.Add(phoneUSBCompatibility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostPhoneUSBCompatibility", new { id = phoneUSBCompatibility.Id }, phoneUSBCompatibility);
        }

        // DELETE: api/PhoneUSBCompatibilities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneUSBCompatibility>> DeletePhoneUSBCompatibility(int id)
        {
            var phoneUSBCompatibility = await _context.PhoneUSBCompatibility.FindAsync(id);
            if (phoneUSBCompatibility == null)
            {
                return NotFound();
            }

            _context.PhoneUSBCompatibility.Remove(phoneUSBCompatibility);
            await _context.SaveChangesAsync();

            return phoneUSBCompatibility;
        }

        private bool PhoneUSBCompatibilityExists(int id)
        {
            return _context.PhoneUSBCompatibility.Any(e => e.Id == id);
        }
    }
}
