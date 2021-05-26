using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Carteira
    {
        [Key]
        public int CarteiraID { get; set; }
        public string Saldo { get; set; }

        //Propriedades de Navegação
        [ForeignKey("Passageiro")]
        public int PessoaID { get; set; }
        public virtual Passageiro Passageiro { get; set; }
        public virtual List<Pagamento>Pagamentos { get; set; }
    }
}
