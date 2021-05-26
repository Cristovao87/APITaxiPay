using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTaxiPay.Models
{
    public class Rota
    {
        [Key]
        public int RotaID { get; set; }
        public double Custo { get; set; }
        public string Estado { get; set; }

        //Propriedade de Navegação
        [ForeignKey("Destino")]
        public int DestinoID { get; set; }
        public virtual Destino Destino { get; set; }
        [ForeignKey("Origem")]
        public int OrigemID { get; set; }
        public virtual Origem Origem { get; set; }
        public virtual Corrida Corrida { get; set; }
    }
}
