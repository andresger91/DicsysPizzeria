using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class IngredientePizzaService
    {
        public static void Save(IngredientePizza nuevo)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    ctx.IngredientePizza.Add(nuevo);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }
    }
}
