﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string nombre { get; set; }

        public List<Pedido> Pedido { get; set; }
    }
}