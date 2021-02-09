using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }

        public int TamañoId { get; set; }

        public Tamaño Tamaño { get; set; }

        public int TipoId { get; set; }

        public Tipo Tipo { get; set; }

        public List<DetallePedido> DetallePedido { get; set; }

    }
}
