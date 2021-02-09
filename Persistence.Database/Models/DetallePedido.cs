using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class DetallePedido
    {
        public int Id { get; set; }

        public int cantidad { get; set; }

        public string tamaño { get; set; }

        public string tipo { get; set; }

        public int precio { get; set; }

        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }
    }
}
