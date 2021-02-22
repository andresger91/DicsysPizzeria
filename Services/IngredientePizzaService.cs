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
        
        public static List<IngredientePizza> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<IngredientePizza> pizza_ingrediente = ctx.IngredientePizza.ToList();

                return pizza_ingrediente;
            }
        }

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
