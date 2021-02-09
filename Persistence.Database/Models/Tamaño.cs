using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Tamaño
    {
        public int Id{ get; set; }
        public string nombre { get; set; }
        public int cant_porciones { get; set; }

        public List<Pizza> Pizza { get; set; }
    }
}
