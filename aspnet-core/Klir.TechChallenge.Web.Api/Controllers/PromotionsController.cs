using Klir.TechChallenge.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public PromotionsController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotions>>> GetPromotions()
        {
            return await _context.Promotions.ToListAsync();
        }

        //Get: api/Promotions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotions>> GetPromotionbyId(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return promotion;
        }

        //PUT: api/Promotions/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePromotion(int id, Promotions promotion)
        {
            if (id != promotion.Id)
            {
                return BadRequest();
            }

            _context.Entry(promotion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromotionExists(id))
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

        //POST: api/Promotions
        [HttpPost]
        public async Task<ActionResult<Products>> InsertPromotion(Promotions promotion)
        {
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPromotions", new { id = promotion.Id }, promotion);
        }

        //DELETE: api/Promotions/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Promotions>> DeletePromotion(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }

            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();

            return promotion;
        }
        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(p => p.Id == id);
        }
    }
}
