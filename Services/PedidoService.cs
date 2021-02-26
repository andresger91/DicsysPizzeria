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
        public static void Save(Pedido pedido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (pedido.Id != 0)
                        ctx.Entry(pedido).State = EntityState.Modified;
                    
                    else
                        ctx.Pedido.Add(pedido);
                    ctx.SaveChanges();
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

        public static List<Pedido> GetPedidosACancelar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> pedidos = ctx.Pedido.Where(s=> s.estado == "Encargado" || s.estado == "EnPreparacion").ToList();

                return pedidos;
            }
        }

        public static List<Pedido> GetPedidosAFacturar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> pedidos = ctx.Pedido.Where(s => s.estado == "Preparado" || s.estado == "Entregado").ToList();

                return pedidos;
            }
        }

        public static List<Pedido> GetPedidosAEncargar()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> pedidos = ctx.Pedido.Where(s => s.estado == "Encargado").ToList();

                return pedidos;
            }
        }

    }
}
