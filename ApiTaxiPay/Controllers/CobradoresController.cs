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
    public class CobradoresController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public CobradoresController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Cobradores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cobrador>>> GetCobradores()
        {
            return await _context.Cobradores.ToListAsync();
        }

        // GET: api/Cobradores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cobrador>> GetCobrador(int id)
        {
            var cobrador = await _context.Cobradores.FindAsync(id);

            if (cobrador == null)
            {
                return NotFound();
            }

            return cobrador;
        }

        // PUT: api/Cobradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCobrador(int id, Cobrador cobrador)
        {
            if (id != cobrador.PessoaID)
            {
                return BadRequest();
            }

            _context.Entry(cobrador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobradorExists(id))
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

        // POST: api/Cobradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cobrador>> PostCobrador(Cobrador cobrador)
        {
            _context.Cobradores.Add(cobrador);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CobradorExists(cobrador.PessoaID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCobrador", new { id = cobrador.PessoaID }, cobrador);
        }

        // DELETE: api/Cobradores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCobrador(int id)
        {
            var cobrador = await _context.Cobradores.FindAsync(id);
            if (cobrador == null)
            {
                return NotFound();
            }

            _context.Cobradores.Remove(cobrador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CobradorExists(int id)
        {
            return _context.Cobradores.Any(e => e.PessoaID == id);
        }
    }
}
