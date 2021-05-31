using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITaxiPay.Dados;
using APITaxiPay.Models;

namespace APITaxiPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigensController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public OrigensController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Origens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Origem>>> GetOrigens()
        {
            return await _context.Origens.ToListAsync();
        }

        // GET: api/Origens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Origem>> GetOrigem(int id)
        {
            var origem = await _context.Origens.FindAsync(id);

            if (origem == null)
            {
                return NotFound();
            }

            return origem;
        }

        // PUT: api/Origens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrigem(int id, Origem origem)
        {
            if (id != origem.OrigemID)
            {
                return BadRequest();
            }

            _context.Entry(origem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrigemExists(id))
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

        // POST: api/Origens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Origem>> PostOrigem(Origem origem)
        {
            _context.Origens.Add(origem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrigem", new { id = origem.OrigemID }, origem);
        }

        // DELETE: api/Origens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrigem(int id)
        {
            var origem = await _context.Origens.FindAsync(id);
            if (origem == null)
            {
                return NotFound();
            }

            _context.Origens.Remove(origem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrigemExists(int id)
        {
            return _context.Origens.Any(e => e.OrigemID == id);
        }
    }
}
