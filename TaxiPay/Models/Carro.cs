using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxiPay.Models
{
    public class Carro
    {
        [Key]
        public int CarroID { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }

        //Propriedades de Navegação
        public virtual List<Diaria>Diarias { get; set; }
        [ForeignKey("Motorista")]
        public int PessoaID { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}
