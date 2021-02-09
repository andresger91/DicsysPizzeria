using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }

        public string nombre { get; set; }

        public List<Pizza> Pizzas { get; set; }

    }
}
