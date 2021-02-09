using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime fechaHoraEmision { get; set; }
        public DateTime fechaHoraEstimada { get; set; }
        public string nombreCliente { get; set; }

        public string estado { get; set; }

        public List<Factura> Factura { get; set; }

        public List<DetallePedido> DetallePedido { get; set; }

    }
}
