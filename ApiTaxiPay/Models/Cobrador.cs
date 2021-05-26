using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Cobrador
    {
        [Key]
        [ForeignKey("Pessoa")]
        public int PessoaID { get; set; }
        public string NumeroAssociado { get; set; }

        //Propriedades de Navegação
        public virtual Pessoa Pessoa { get; set; }
        public virtual List<Diaria>Diarias { get; set; }
    }
}
