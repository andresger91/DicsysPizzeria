using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class IngredientePizza
    {
        public int PizzaId { get; set; }

        public int IngredienteId { get; set; }

        public Pizza Pizza { get; set; }

        public Ingrediente Ingrediente { get; set; }
    }
}
