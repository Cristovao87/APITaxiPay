using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Corrida
    {
        [Key]
        public int CorridaID { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public double Valor { get; set; }
        public string Estado { get; set; }

        // Propriedades de Navegação
        [ForeignKey("Rota")]
        public int RotaID { get; set; }
        public virtual Rota Rota { get; set; }
        public virtual List<Pagamento>Pagamentos { get; set; }
        [ForeignKey("Diaria")]
        public int DiariaID { get; set; }
        public virtual Diaria Diaria { get; set; }

    }
}
