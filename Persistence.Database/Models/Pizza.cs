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
        public List<DetallePedido> DetallePedido { get; set; }

        public List<IngredientePizza> IngredientePizza { get; set; }

    }
}
