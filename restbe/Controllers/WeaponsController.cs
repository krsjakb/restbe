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
    public class WeaponsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public WeaponsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Weapons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponModel>>> GetWeaponModel()
        {
            return await _context.WeaponModel.ToListAsync();
        }

        // GET: api/Weapons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponModel>> GetWeaponModel(int id)
        {
            var weaponModel = await _context.WeaponModel.FindAsync(id);

            if (weaponModel == null)
            {
                return NotFound();
            }

            return weaponModel;
        }

        // PUT: api/Weapons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponModel(int id, WeaponModel weaponModel)
        {
            if (id != weaponModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponModelExists(id))
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

        // POST: api/Weapons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeaponModel>> PostWeaponModel(WeaponModel weaponModel)
        {
            _context.WeaponModel.Add(weaponModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponModel", new { id = weaponModel.Id }, weaponModel);
        }

        // DELETE: api/Weapons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeaponModel>> DeleteWeaponModel(int id)
        {
            var weaponModel = await _context.WeaponModel.FindAsync(id);
            if (weaponModel == null)
            {
                return NotFound();
            }

            _context.WeaponModel.Remove(weaponModel);
            await _context.SaveChangesAsync();

            return weaponModel;
        }

        private bool WeaponModelExists(int id)
        {
            return _context.WeaponModel.Any(e => e.Id == id);
        }
    }
}
