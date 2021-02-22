using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class DetallePedidoConfig
    {
        public DetallePedidoConfig(EntityTypeBuilder<DetallePedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => new { x.Id, x.PedidoId });
            entityTypeBuilder
            .HasOne(pt => pt.Pedido)
            .WithMany(p => p.DetallePedido)
            .HasForeignKey(pt => pt.PedidoId);
        }
    }
}
