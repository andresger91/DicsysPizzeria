using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Factura
    {
        public int Id { get; set; }

        public DateTime fechaHoraEmision { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido{ get; set; }
    }
}
