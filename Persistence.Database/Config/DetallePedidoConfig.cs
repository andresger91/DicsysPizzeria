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
        }
    }
}
