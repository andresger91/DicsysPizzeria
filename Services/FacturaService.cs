using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class FacturaService
    {
        public static void Save(Factura factura)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (factura.Id != 0)
                        ctx.Entry(factura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    else
                        ctx.Factura.Add(factura);

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static List<Factura> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Factura> facturas = ctx.Factura.ToList();

                return facturas;
            }
        }

        public static List<Factura> GetFacturaByTime(DateTime fechaDesde, DateTime fechaHasta)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Factura> facturas = ctx.Factura.Where(x => x.fechaHoraEmision >= fechaDesde && x.fechaHoraEmision <= fechaHasta).ToList();

                return facturas;
            }

        }
    }

    
}
