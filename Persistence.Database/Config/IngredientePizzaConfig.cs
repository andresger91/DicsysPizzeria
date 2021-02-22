using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class IngredientePizzaConfig
    {
        public IngredientePizzaConfig(EntityTypeBuilder<IngredientePizza> entityTypeBuilder)
        {
            //define las claves primarias
            entityTypeBuilder.HasKey(t => new { t.PizzaId, t.IngredienteId });

            //define las claves foráneas
            entityTypeBuilder
            .HasOne(pt => pt.Pizza)
            .WithMany(p => p.IngredientePizza)
            .HasForeignKey(pt => pt.PizzaId);

            entityTypeBuilder
                .HasOne(pt => pt.Ingrediente)
                .WithMany(t => t.IngredientePizza)
                .HasForeignKey(pt => pt.IngredienteId);
        }
    }
}
