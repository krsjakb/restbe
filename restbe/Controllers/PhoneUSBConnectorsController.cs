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
    public class PhoneUSBConnectorsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public PhoneUSBConnectorsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/PhoneUSBConnectors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneUSBConnector>>> GetPhoneUSBConnector()
        {
            return await _context.PhoneUSBConnector.Include(pu => pu.Phone)
                                                   .Include(pu => pu.USBConnector)
                                                   .ToListAsync();
        }

        // GET: api/PhoneUSBConnectors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneUSBConnector>> GetPhoneUSBConnector(int id)
        {
            var phoneUSBConnector = await _context.PhoneUSBConnector.Include(pu => pu.Phone)
                                                                    .Include(pu => pu.USBConnector)
                                                                    .FirstOrDefaultAsync(pu => pu.Id == id);

            if (phoneUSBConnector == null)
            {
                return NotFound();
            }

            return phoneUSBConnector;
        }

        // PUT: api/PhoneUSBConnectors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneUSBConnector(int id, PhoneUSBConnector phoneUSBConnector)
        {
            if (id != phoneUSBConnector.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneUSBConnector).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneUSBConnectorExists(id))
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

        // POST: api/PhoneUSBConnectors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhoneUSBConnector>> PostPhoneUSBConnector(PhoneUSBConnector phoneUSBConnector)
        {
            _context.PhoneUSBConnector.Add(phoneUSBConnector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneUSBConnector", new { id = phoneUSBConnector.Id }, phoneUSBConnector);
        }

        // DELETE: api/PhoneUSBConnectors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneUSBConnector>> DeletePhoneUSBConnector(int id)
        {
            var phoneUSBConnector = await _context.PhoneUSBConnector.FindAsync(id);
            if (phoneUSBConnector == null)
            {
                return NotFound();
            }

            _context.PhoneUSBConnector.Remove(phoneUSBConnector);
            await _context.SaveChangesAsync();

            return phoneUSBConnector;
        }

        private bool PhoneUSBConnectorExists(int id)
        {
            return _context.PhoneUSBConnector.Any(e => e.Id == id);
        }
    }
}
