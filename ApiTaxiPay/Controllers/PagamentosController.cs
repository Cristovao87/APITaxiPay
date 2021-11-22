using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITaxiPay.Dados;
using APITaxiPay.Models;
using Amazon.DynamoDBv2;
using Microsoft.Data.SqlClient;

namespace APITaxiPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly TaxiPayContexto _context;

        public PagamentosController(TaxiPayContexto context)
        {
            _context = context;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos()
        {
            return await _context.Pagamentos.ToListAsync();
        }

        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagamento>> GetPagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);

            if (pagamento == null)
            {
                return NotFound();
            }

            return pagamento;
        }

        // PUT: api/Pagamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamento(int id, Pagamento pagamento)
        {
            if (id != pagamento.PagamentoID)
            {
                return BadRequest();
            }

            _context.Entry(pagamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentoExists(id))
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

        // POST: api/Pagamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagamento", new { id = pagamento.PagamentoID }, pagamento);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamento(int id)
        {
            var pagamento = await _context.Pagamentos.FindAsync(id);
            if (pagamento == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PagamentoExists(int id)
        {
            return _context.Pagamentos.Any(e => e.PagamentoID == id);
        }



        // Método para efectuar um pagamento
      /*  [HttpPatch]
        public async Task<ActionResult<int>> PostPagar(Pagamento pagamento, int idCarteira, int idCorrida, decimal valor, string tipo, string estado)
        {
            using var transaction = _context.Database.BeginTransaction();

            int corridaId = idCorrida;
            int carteiraId = idCarteira;
            // Buscar o valor disponivel na carteira do Passageiro
            //string saldoCarteira = "SELECT Saldo FROM Carteira WHERE CarteiraID = @idCarteira";

            var saldoCarteira = _context.Carteiras.FromSqlRaw("SELECT Saldo FROM Carteira WHERE CarteiraID = @idCarteira", idCarteira).FirstOrDefault();
            
            decimal valorDisponivel = System.Convert.ToDecimal(saldoCarteira);
           

           var valordisponivel = await _context.Carteiras
                .Include(p => p.Saldo)
                .ToListAsync(); 

           if (valorDisponivel >= valor)
            {
                try
                {

                    string query = "UPDATE Carteira SET Saldo = Saldo - @valor WHERE CarteiraID = @IdCarteira";
                    //Update tbCarteira set Saldo = Saldo - valor where IdCarteira=inpIdCarteira
                    decimal updateCarteira = System.Convert.ToDecimal(query);

                    //Inserir new pagamento 

                    var commandText = "INSERT INTO[Pagamento](Valor, Tempo, Tipo, Estado, CorridaID, CarteiraID) VALUES(@valor, @dataPgto, @tipo, @estado, @idCorrida, @idCarteira)";

                    SqlCommand command = new SqlCommand();
                    //var parameter = new SqlParameter();
                    command.Parameters.AddWithValue("@valor", pagamento.Valor);
                    command.Parameters.AddWithValue("@dataPgto", pagamento.Tempo);
                    command.Parameters.AddWithValue("@tipo", pagamento.Tipo);
                    command.Parameters.AddWithValue("@estado", pagamento.Estado);
                    command.Parameters.AddWithValue("@idCorrida", pagamento.CorridaID);
                    command.Parameters.AddWithValue("@idCarteira", pagamento.CarteiraID);

                    await _context.Database.ExecuteSqlRawAsync(commandText, command);

                    transaction.Commit();
                    }
                
                catch (Exception)
                {
                   transaction.Rollback();
        

                }
            }
            return 1;
        }
       
       



        */


    }


}
