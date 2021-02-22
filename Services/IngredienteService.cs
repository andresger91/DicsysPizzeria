using Microsoft.EntityFrameworkCore;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class IngredienteService
    {
        public static Ingrediente Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Ingrediente ingrediente = ctx.Ingrediente.Where(p => p.Id == Id)
                    .Include(t => t.IngredientePizza).FirstOrDefault();

                return ingrediente;
            }
        }

        public static List<Ingrediente> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Ingrediente> ingredientes = ctx.Ingrediente.ToList();

                return ingredientes;
            }
        }

        public static void Save(Ingrediente ingrediente)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (ingrediente.Id != 0)
                    {
                        ctx.Entry(ingrediente).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Ingrediente.Add(ingrediente);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static List<Ingrediente> BuscarPorContenido(string contenido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Ingrediente> ListaIngredientes = ctx.Ingrediente.Where(p => p.nombre.Contains(contenido)).ToList();

                return ListaIngredientes;
            }
        }

        public static bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Ingrediente resultado = Get(Id);

                if (resultado != null)
                {
                    ctx.Ingrediente.Remove(resultado);

                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
