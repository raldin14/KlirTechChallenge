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
    public class ShoppingCartController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public ShoppingCartController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetShoppingCart()
        {
            return await _context.ShoppingCart.ToListAsync();
        }

        //Get: api/ShoppingCart/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartbyId(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);

            if (shoppingCart == null)
            {
                return NotFound();
            }

            return shoppingCart;
        }

        //PUT: api/ShoppingCart/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShoppingCart(int id, ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartExists(id))
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

        //POST: api/ShoppingCart
        [HttpPost]
        public async Task<ActionResult<Products>> InsertPromotion(ShoppingCart shoppingCart)
        {
            _context.ShoppingCart.Add(shoppingCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCart", new { id = shoppingCart.Id }, shoppingCart);
        }

        //DELETE: api/ShoppingCart/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingCart>> DeleteShoppingCart(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            _context.ShoppingCart.Remove(shoppingCart);
            await _context.SaveChangesAsync();

            return shoppingCart;
        }
        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCart.Any(p => p.Id == id);
        }
    }
}
