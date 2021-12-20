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
    public class JobsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public JobsController(MainDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jobs>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jobs>> GetJobs(long id)
        {
            var jobs = await _context.Jobs.FirstAsync(i => i.Id == id);

            if (jobs == null)
            {
                return NotFound();
            }

            return jobs;
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobs(long id, Jobs job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobsExists(id))
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
        public async Task<ActionResult<Jobs>> PostJobs(Jobs job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobs", new { id = job.Id }, job);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Jobs>> DeleteJobs(long id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return job;
        }

        private bool JobsExists(long id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
