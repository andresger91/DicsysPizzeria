using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class FacturaService
    {
        public void Add() { }

        public static List<Factura> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Factura> facturas = ctx.Factura.ToList();

                return facturas;
            }
        }
    }

    
}
