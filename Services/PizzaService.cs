using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PizzaService
    {
        public static void Save(Pizza pizza)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (pizza.Id != 0)
                    {
                        ctx.Entry(pizza).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Pizza.Add(pizza);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static Pizza Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pizza pizza = ctx.Pizza.Where(t => t.Id == Id)
                    .Include(t => t.IngredientePizza).FirstOrDefault();
                return pizza;
            }
        }

        public static List<Pizza> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pizza> pizzas = ctx.Pizza.ToList();
                return pizzas;
            }
        }

    }
}
