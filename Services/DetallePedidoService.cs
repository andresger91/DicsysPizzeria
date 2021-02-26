using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class DetallePedidoService
    {
        public static void Save(DetallePedido detallepedido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (detallepedido.Id != 0)
                    {
                        ctx.Entry(detallepedido).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.DetallePedido.Add(detallepedido);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static DetallePedido GetById(int Id, int Id2)
        {
            using (var ctx = new ApplicationDbContext())
            {
                DetallePedido detalle = ctx.DetallePedido.Where(t => t.Id == Id && t.PedidoId == Id2)
                    .Include(t => t.Pizza).FirstOrDefault();
                return detalle;
            }
        }

    }
}
