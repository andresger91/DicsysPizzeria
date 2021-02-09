using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PedidoService
    {
        public void Add(Pedido pedido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    ctx.Pedido.Add(pedido);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public void Cancel(Pedido pedido) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (pedido.estado == "Encargado" || pedido.estado =="EnPreparacion")
                    {
                        ctx.Entry(pedido).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static Pedido GetById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pedido pedido = ctx.Pedido.Where(t => t.Id == Id)
                    .Include(t => t.DetallePedido).FirstOrDefault();
                return pedido;
            }
        }

        public static List<Pedido> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> pedidos = ctx.Pedido.ToList();

                return pedidos;
            }
        }
    }
}
