﻿using Persistence.Database.Models;
using System;
using System.Collections.Generic;

namespace DicsysProyectoPizzeria
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu();

            static void Menu()
            {
                bool ejecucion = true;

                String[] nombreEstados = { "Encargado", "EnPreparacion", "Preparado", "Entregado","Cancelado" };
                while (ejecucion)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Elegir una opción:");
                    Console.WriteLine("1- Ingresar/modificar precio a la pizza");
                    Console.WriteLine("2- Crear pedido");
                    Console.WriteLine("3- Crear detalle y añadir a un pedido");
                    Console.WriteLine("4- Modificar detalle/s de un pedido");
                    Console.WriteLine("5- Cambiar estado de un pedido");
                    Console.WriteLine("6- Mostrar datos de un pedido y sus detalles");
                    Console.WriteLine("7- Mostrar pedidos");
                    Console.WriteLine("8- Generar factura");
                    Console.WriteLine("9- Mostrar facturas");
                    Console.WriteLine("0- SALIR:");
                    var opcion = Int32.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            ejecucion = false;
                            break;
                        case 1:
                            if(Services.PizzaService.GetAll().Count == 0 && Services.IngredienteService.GetAll().Count == 0)
                            {
                                String[] nombrePizzas = { "Mozzarrella", "Napolitana", "Fugazzeta", "Primavera", "Anchoas", "Roquefort" };
                                String[] nombreIngredientes = { "Salsa de Tomate", "Tomate", "Mozzarrella", "Queso", "Oregano", "Aceitunas", "Jamon", "Cebolla", "Ajo", "Anchoas", "Aji", "QuesoRoquefort" };

                                //cargar las pizzas y los ingredientes
                                foreach (string nombrePizza in nombrePizzas)
                                {
                                    var pizza = new Pizza { nombre = nombrePizza };
                                    Services.PizzaService.Save(pizza);
                                }

                                foreach (string nombreIng in nombreIngredientes)
                                {
                                    var ingrediente = new Ingrediente { nombre = nombreIng };
                                    Services.IngredienteService.Save(ingrediente);
                                }
                                List<Pizza> pizzas = Services.PizzaService.GetAll();
                                List<Ingrediente> ingredientes = Services.IngredienteService.GetAll();

                                foreach (var i in pizzas)
                                {
                                    foreach (var j in ingredientes)
                                    {
                                        if ((j.Id == 1 || j.Id == 3 || j.Id == 5 || j.Id == 6) && i.Id == 1)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                        if ((j.Id == 1 || j.Id == 2 || j.Id == 3 || j.Id == 5 || j.Id == 6 || j.Id == 9) && i.Id == 2)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                        if ((j.Id == 3 || j.Id == 4 || j.Id == 6 || j.Id == 8) && i.Id == 3)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                        if ((j.Id == 1 || j.Id == 2 || j.Id == 3 || j.Id == 5 || j.Id == 6 || j.Id == 7) && i.Id == 4)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                        if ((j.Id == 1 || j.Id == 3 || j.Id == 5 || j.Id == 6 || j.Id == 10 || j.Id == 11) && i.Id == 5)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                        if ((j.Id == 1 || j.Id == 3 || j.Id == 6 || j.Id == 12) && i.Id == 6)
                                            GuardarIngredientePizza(i.Id, j.Id);
                                    }
                                }

                                static void GuardarIngredientePizza(int i, int j)
                                {
                                    IngredientePizza x = new IngredientePizza { PizzaId = i, IngredienteId = j };
                                    Services.IngredientePizzaService.Save(x);
                                }
                            }
                            List<Pizza> pizzas1 = Services.PizzaService.GetAll();
                            Console.WriteLine("-Insertar precio de las pizzas-");
                            foreach (var t in pizzas1)
                            {
                                Console.Write("- " + t.nombre + ", precio: ");
                                int precio = Int32.Parse(Console.ReadLine());
                                if (precio >= 0)
                                {
                                    t.precio = precio;
                                }
                                Services.PizzaService.Save(t);
                            }
                            break;
                        case 2:
                            Console.Write("Ingrese nombre de cliente: ");
                            string nombreCliente = Console.ReadLine();
                            Console.Write("Ingrese tiempo de demora en minutos: ");
                            int dem = Int32.Parse(Console.ReadLine());
                            Pedido nuevo = new Pedido { nombreCliente = nombreCliente, fechaHoraEmision = DateTime.Now, estado = nombreEstados[0], fechaHoraEstimada = DateTime.Now.AddMinutes(dem) };
                            Services.PedidoService.Save(nuevo);
                            break;
                        case 3:
                            String[] nombreTipo = { "A la piedra", "A la parrilla", "Al horno" };
                            String[] nombreTamaño = { "4 porciones", "8 porciones", "12 porciones" };
                            double[] porcentajesTipo = { 1.5, 1.3, 1.1 };
                            double[] porcentajesTamaño = { 1.0, 1.8, 2.6 };
                            Console.Write("Ingrese numero de pedido para añadir detalle: ");
                            var ingPed = Int32.Parse(Console.ReadLine());
                            Pedido buscar = Services.PedidoService.GetById(ingPed);
                            if(buscar!=null)
                            {
                                foreach (var i in Services.PizzaService.GetAll())
                                    Console.WriteLine(i.Id + " - " + i.nombre);
                                Console.Write("Elija una pizza: ");
                                var ing1 = Int32.Parse(Console.ReadLine());
                                Pizza pedPizza = Services.PizzaService.Get(ing1);
                                Console.Write("Ingrese la cantidad de pizzas: ");
                                var ing2 = Int32.Parse(Console.ReadLine());
                                for(int i=0; i<nombreTipo.Length;i++)
                                    Console.WriteLine(i+" - "+nombreTipo[i]);
                                Console.Write("Elija un tipo: ");
                                var ing3 = Int32.Parse(Console.ReadLine());
                                for (int i = 0; i < nombreTamaño.Length; i++)
                                    Console.WriteLine(i + " - " + nombreTamaño[i]);
                                Console.Write("Elija un tamaño: ");
                                var ing4 = Int32.Parse(Console.ReadLine());
                                int subTotal = (int)(pedPizza.precio * porcentajesTamaño[ing4] * porcentajesTipo[ing3])*ing2;
                                DetallePedido nuevoDetalle = new DetallePedido { PizzaId = ing1, cantidad = ing2, tipo = nombreTipo[ing3], tamaño = nombreTipo[ing4], precio = subTotal, PedidoId = buscar.Id };
                                Services.DetallePedidoService.Save(nuevoDetalle);
                            }
                            break;
                        case 4:

                            break;
                        case 5:
                            List<Pedido> ped;
                            Pedido pedSel;
                            Console.Write("Desea cancelar algun pedido (0-si,1-no): ");
                            var res = Int32.Parse(Console.ReadLine());
                            if (res == 0)
                            {
                                ped = Services.PedidoService.GetPedidosACancelar();
                                if (ped.Count > 0)
                                {
                                    foreach (var i in ped)
                                        Console.WriteLine(i.Id + " - " + i.nombreCliente + " - " + i.estado);
                                    Console.Write("Seleccione un pedido para cancelar: ");
                                    var idCancel = Int32.Parse(Console.ReadLine());
                                    pedSel = Services.PedidoService.GetById(idCancel);
                                    if (pedSel != null)
                                    {
                                        pedSel.estado = nombreEstados[4];
                                        Services.PedidoService.Save(pedSel);
                                    }
                                }
                                else
                                    Console.WriteLine("No existen pedidos para cancelar");
                            }
                            else
                            {
                                ped = Services.PedidoService.GetAll();
                                foreach (var i in ped)
                                    Console.WriteLine(i.Id + " - " + i.nombreCliente + " - " + i.estado);
                                Console.Write("Seleccione un pedido para cambiar su estado: ");
                                var idSel = Int32.Parse(Console.ReadLine());
                                pedSel = Services.PedidoService.GetById(idSel);
                                if (pedSel != null)
                                {
                                    for (int i=0; i < nombreEstados.Length; i++)
                                    {
                                        if (pedSel.estado.Equals(nombreEstados[i]) && i<3 )
                                        {
                                            pedSel.estado = nombreEstados[i + 1];
                                            break;
                                        }
                                    }
                                    Services.PedidoService.Save(pedSel);
                                }
                            }
                            break;
                        case 6:
                            Console.Write("Ingrese id de pedido: ");
                            var iBusq = Int32.Parse(Console.ReadLine());
                            Pedido busq = Services.PedidoService.GetById(iBusq);
                            if (busq != null)
                            {
                                Console.WriteLine("--Datos del pedido del cliente--");
                                Console.WriteLine(busq.Id + " - " + busq.fechaHoraEmision + " - " + busq.nombreCliente + " - " + busq.estado);
                            }
                            break;
                        case 7:
                            List<Pedido> todo = Services.PedidoService.GetAll();
                            Console.WriteLine("--Todos los Pedidos de la pizzeria--");
                            foreach(var i in todo)
                                Console.WriteLine(i.Id + " - "+i.fechaHoraEmision+" - " + i.nombreCliente + " - " + i.estado);
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        default:
                            Console.WriteLine("No existe esa opción.");
                            break;
                    }
                }
            }
        }
    }
}
