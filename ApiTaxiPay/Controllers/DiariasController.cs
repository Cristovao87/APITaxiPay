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
    public class DiariasController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public DiariasController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Diarias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diaria>>> GetDiarias()
        {
            return await _context.Diarias.ToListAsync();
        }

        // GET: api/Diarias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diaria>> GetDiaria(int id)
        {
            var diaria = await _context.Diarias.FindAsync(id);

            if (diaria == null)
            {
                return NotFound();
            }

            return diaria;
        }

        // PUT: api/Diarias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaria(int id, Diaria diaria)
        {
            if (id != diaria.DiariaID)
            {
                return BadRequest();
            }

            _context.Entry(diaria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiariaExists(id))
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

        // POST: api/Diarias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diaria>> PostDiaria(Diaria diaria)
        {
            _context.Diarias.Add(diaria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiaria", new { id = diaria.DiariaID }, diaria);
        }

        // DELETE: api/Diarias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaria(int id)
        {
            var diaria = await _context.Diarias.FindAsync(id);
            if (diaria == null)
            {
                return NotFound();
            }

            _context.Diarias.Remove(diaria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiariaExists(int id)
        {
            return _context.Diarias.Any(e => e.DiariaID == id);
        }
    }
}
