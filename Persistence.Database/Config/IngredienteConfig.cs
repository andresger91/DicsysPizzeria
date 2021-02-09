using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class IngredienteConfig
    {

        public IngredienteConfig(EntityTypeBuilder<Ingrediente> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.nombre).HasMaxLength(50).IsRequired();
            entityTypeBuilder.HasIndex(x => x.nombre).IsUnique();
        }
    }
}
