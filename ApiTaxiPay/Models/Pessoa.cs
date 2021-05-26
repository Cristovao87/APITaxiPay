using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Estado { get; set; }

        //Propriedades de Navegação
        public virtual Passageiro Passageiro { get; set; }
        public virtual Motorista Motorista { get; set; }
        public virtual Cobrador Cobrador { get; set; }
    }
}
