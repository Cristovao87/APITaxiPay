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
    public class CorridasController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public CorridasController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Corridas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Corrida>>> GetCorridas()
        {
            return await _context.Corridas.ToListAsync();
        }

        // GET: api/Corridas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Corrida>> GetCorrida(int id)
        {
            var corrida = await _context.Corridas.FindAsync(id);

            if (corrida == null)
            {
                return NotFound();
            }

            return corrida;
        }

        // PUT: api/Corridas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorrida(int id, Corrida corrida)
        {
            if (id != corrida.CorridaID)
            {
                return BadRequest();
            }

            _context.Entry(corrida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorridaExists(id))
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

        // POST: api/Corridas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Corrida>> PostCorrida(Corrida corrida)
        {
            _context.Corridas.Add(corrida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCorrida", new { id = corrida.CorridaID }, corrida);
        }

        // DELETE: api/Corridas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorrida(int id)
        {
            var corrida = await _context.Corridas.FindAsync(id);
            if (corrida == null)
            {
                return NotFound();
            }

            _context.Corridas.Remove(corrida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CorridaExists(int id)
        {
            return _context.Corridas.Any(e => e.CorridaID == id);
        }
    }
}
