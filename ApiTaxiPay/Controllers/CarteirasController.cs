using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTaxiPay.Dados;
using ApiTaxiPay.Models;

namespace APITaxiPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarteirasController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public CarteirasController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Carteiras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carteira>>> GetCarteiras()
        {
            return await _context.Carteiras.ToListAsync();
        }

        // GET: api/Carteiras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carteira>> GetCarteira(int id)
        {
            var carteira = await _context.Carteiras.FindAsync(id);

            if (carteira == null)
            {
                return NotFound();
            }

            return carteira;
        }

        // PUT: api/Carteiras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarteira(int id, Carteira carteira)
        {
            if (id != carteira.CarteiraID)
            {
                return BadRequest();
            }

            _context.Entry(carteira).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarteiraExists(id))
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

        // POST: api/Carteiras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carteira>> PostCarteira(Carteira carteira)
        {
            _context.Carteiras.Add(carteira);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarteira", new { id = carteira.CarteiraID }, carteira);
        }

        // DELETE: api/Carteiras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarteira(int id)
        {
            var carteira = await _context.Carteiras.FindAsync(id);
            if (carteira == null)
            {
                return NotFound();
            }

            _context.Carteiras.Remove(carteira);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarteiraExists(int id)
        {
            return _context.Carteiras.Any(e => e.CarteiraID == id);
        }
    }
}
