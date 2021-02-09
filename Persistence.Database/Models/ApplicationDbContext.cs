using Microsoft.EntityFrameworkCore;
using Persistence.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Models
{
    class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;InitialCatalog = Pizzeria; Integrated Security = True");
        }

        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Tamaño> Tamaño { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PedidoConfig(modelBuilder.Entity<Pedido>());
            new FacturaConfig(modelBuilder.Entity<Factura>());
            new DetallePedidoConfig(modelBuilder.Entity<DetallePedido>());
            new EstadoConfig(modelBuilder.Entity<Estado>());
            new PizzaConfig(modelBuilder.Entity<Pizza>());
            new TamañoConfig(modelBuilder.Entity<Tamaño>());
            new TipoConfig(modelBuilder.Entity<Tipo>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
