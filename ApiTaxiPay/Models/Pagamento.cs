using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxiPay.Models
{
    public class Pagamento
    {
        [Key]
        public int PagamentoID { get; set; }
        public double Valor { get; set; }
        public DateTime Tempo { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }

        //Propriedades de Navegação
        [ForeignKey("Corrida")]
        public int CorridaID { get; set; }
        public virtual Corrida Corrida { get; set; }
        [ForeignKey("Carteira")]
        public int CarteiraID { get; set; }
        public virtual Carteira Carteira { get; set; }
    }
}
