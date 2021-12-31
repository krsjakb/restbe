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
    public class JobAdvertisementsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public JobAdvertisementsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/JobAdvertisements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobAdvertisement>>> GetJobAdvertisement()
        {
            return await _context.JobAdvertisement.ToListAsync();
        }

        // GET: api/JobAdvertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobAdvertisement>> GetJobAdvertisement(int id)
        {
            var jobAdvertisement = await _context.JobAdvertisement.FindAsync(id);

            if (jobAdvertisement == null)
            {
                return NotFound();
            }

            return jobAdvertisement;
        }

        // PUT: api/JobAdvertisements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobAdvertisement(int id, JobAdvertisement jobAdvertisement)
        {
            if (id != jobAdvertisement.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobAdvertisement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobAdvertisementExists(id))
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

        // POST: api/JobAdvertisements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<JobAdvertisement>> PostJobAdvertisement(JobAdvertisement jobAdvertisement)
        {
            _context.JobAdvertisement.Add(jobAdvertisement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobAdvertisement", new { id = jobAdvertisement.Id }, jobAdvertisement);
        }

        // DELETE: api/JobAdvertisements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobAdvertisement>> DeleteJobAdvertisement(int id)
        {
            var jobAdvertisement = await _context.JobAdvertisement.FindAsync(id);
            if (jobAdvertisement == null)
            {
                return NotFound();
            }

            _context.JobAdvertisement.Remove(jobAdvertisement);
            await _context.SaveChangesAsync();

            return jobAdvertisement;
        }

        private bool JobAdvertisementExists(int id)
        {
            return _context.JobAdvertisement.Any(e => e.Id == id);
        }
    }
}
