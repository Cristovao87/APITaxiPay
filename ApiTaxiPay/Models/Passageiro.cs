using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Passageiro
    {
        [Key]
        [ForeignKey("Pessoa")]
        public int PessoaID { get; set; }

        //Propriedades de Navegação
        public virtual Pessoa Pessoa { get; set; }
        public virtual Carteira Carteira { get; set; }
    }
}
