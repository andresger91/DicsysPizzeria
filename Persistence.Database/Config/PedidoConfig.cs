using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class PedidoConfig
    {
        public PedidoConfig(EntityTypeBuilder<Pedido> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.nombreCliente).HasMaxLength(30).IsRequired();
        }
    }
}
