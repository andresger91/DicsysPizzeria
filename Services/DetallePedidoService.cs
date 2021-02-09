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

        public static DetallePedido GetById(int intId)
        {
            using (var ctx = new ApplicationDbContext())
            { 
                return ctx.DetallePedido.Where(x => x.Id == intId).FirstOrDefault<DetallePedido>();
            }
        }


        public static List<DetallePedido> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<DetallePedido> detallePedidos = ctx.DetallePedido.ToList();

                return detallePedidos;
            }
        }

    }
}
