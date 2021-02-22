﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Database.Models;

namespace Persistence.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistence.Database.Models.DetallePedido", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.Property<string>("tamaño")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "PedidoId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("PizzaId");

                    b.ToTable("DetallePedido");
                });

            modelBuilder.Entity("Persistence.Database.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaHoraEmision")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Persistence.Database.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Persistence.Database.Models.IngredientePizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId", "IngredienteId");

                    b.HasIndex("IngredienteId");

                    b.ToTable("IngredientePizza");
                });

            modelBuilder.Entity("Persistence.Database.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaHoraEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaHoraEstimada")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombreCliente")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Persistence.Database.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("nombre")
                        .IsUnique();

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("Persistence.Database.Models.DetallePedido", b =>
                {
                    b.HasOne("Persistence.Database.Models.Pedido", "Pedido")
                        .WithMany("DetallePedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Database.Models.Pizza", "Pizza")
                        .WithMany("DetallePedido")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Persistence.Database.Models.Factura", b =>
                {
                    b.HasOne("Persistence.Database.Models.Pedido", "Pedido")
                        .WithMany("Factura")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Persistence.Database.Models.IngredientePizza", b =>
                {
                    b.HasOne("Persistence.Database.Models.Ingrediente", "Ingrediente")
                        .WithMany("IngredientePizza")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistence.Database.Models.Pizza", "Pizza")
                        .WithMany("IngredientePizza")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("Persistence.Database.Models.Ingrediente", b =>
                {
                    b.Navigation("IngredientePizza");
                });

            modelBuilder.Entity("Persistence.Database.Models.Pedido", b =>
                {
                    b.Navigation("DetallePedido");

                    b.Navigation("Factura");
                });

            modelBuilder.Entity("Persistence.Database.Models.Pizza", b =>
                {
                    b.Navigation("DetallePedido");

                    b.Navigation("IngredientePizza");
                });
#pragma warning restore 612, 618
        }
    }
}
