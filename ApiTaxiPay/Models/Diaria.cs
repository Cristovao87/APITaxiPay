using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxiPay.Models
{
    public class Diaria
    {
        [Key]
        public int DiariaID { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fecho { get; set; }
        public string Estado { get; set; }

        //Propriedades de Navegação
        public virtual List<Corrida>Corridas { get; set; }
        [ForeignKey("Carro")]
        public int CarroID { get; set; }
        public virtual Carro Carro { get; set; }
        [ForeignKey("Motorista, Cobrador")]
        public int PessoaID { get; set; }
        public virtual Motorista Motorista { get; set; }
        public virtual Cobrador Cobrador { get; set; }
    }
}
