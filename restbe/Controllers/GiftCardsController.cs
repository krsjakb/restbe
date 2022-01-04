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
    [Route("api/giftcards")]
    [ApiController]
    public class GiftCardsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GiftCardsController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftCard>>> Get()
        {
            return await _context.GiftCard.ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GiftCard>> Get(int id)
        {
            return await GetOneById(id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GiftCard giftCard)
        {
            if (id != giftCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(giftCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftCardExists(id))
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
        public async Task<ActionResult<GiftCard>> Post(GiftCard giftCard)
        {
            _context.GiftCard.Add(giftCard);
            await _context.SaveChangesAsync();

            return giftCard;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GiftCard>> Delete(int id)
        {
            var res = await GetOneById(id);
            if (res.Result is NotFoundResult)
            {
                return NotFound();
            }

            _context.GiftCard.Remove(res.Value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiftCardExists(int id)
        {
            return _context.GiftCard.Any(e => e.Id == id);
        }

        private async Task<ActionResult<GiftCard>> GetOneById(int id)
        {
            var giftCard = await _context.GiftCard.FindAsync(id);

            if (giftCard == null)
            {
                return NotFound();
            }

            return giftCard;
        }
    }
}
