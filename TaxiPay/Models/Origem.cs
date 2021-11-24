using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaxiPay.Models
{
    public class Origem
    {
        public int OrigemID { get; set; }
        public string Nome { get; set; }

        //Propriedades de Navegação
        public virtual Rota Rota { get; set; }
    }
}
