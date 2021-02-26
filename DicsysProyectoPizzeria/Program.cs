using Persistence.Database.Models;
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
                String[] nombreTipo = { "A la piedra", "A la parrilla", "Al horno" };
                String[] nombreTamaño = { "4 porciones", "8 porciones", "12 porciones" };
                double[] porcentajesTipo = { 1.5, 1.3, 1.1 };
                double[] porcentajesTamaño = { 1.0, 1.8, 2.6 };
                List<Pedido> pedidos;
                Pedido pedidoEnc;

                while (ejecucion)
                {
                    Console.WriteLine("----------Menú de opciones------------");
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
                    Console.Write("Elegir opción: ");
                    var opcion = Int32.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            ejecucion = false;
                            break;
                        case 1:
                            List<Pizza> pizzas = Services.PizzaService.GetAll();
                            List<Ingrediente> ingredientes = Services.IngredienteService.GetAll();
                            //verifica si la tabla pizza e ingrediente tienen datos. En caso que no, ingresa de forma automática por única vez
                            if (pizzas.Count == 0 && ingredientes.Count == 0)
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
                                
                                pizzas = Services.PizzaService.GetAll();
                                ingredientes = Services.IngredienteService.GetAll();
                                
                                //cargar la tabla intermedia ingrediente_pizza
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
                            Console.WriteLine("-Insertar precio de las pizzas-");
                            foreach (var t in pizzas)
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
                            Pedido nuevo = new Pedido { nombreCliente = nombreCliente, fechaHoraEmision = DateTime.Now, estado = nombreEstados[0], fechaHoraEstimada = DateTime.Now };
                            Services.PedidoService.Save(nuevo);
                            break;
                        case 3:
                            Console.Write("Ingrese numero de pedido para añadir detalle: ");
                            pedidoEnc = buscarPedido();
                            //verifica que el pedido existe y tenga estado encargado
                            if ( pedidoEnc!=null && pedidoEnc.estado.Equals(nombreEstados[0]))
                            {
                                int ing2, ing3, ing4;
                                Pizza pedPizza = elegirPizza();
                                ing2 = ingresarCantidad("");
                                ing3 = elegirTipo_Tamaño(nombreTipo,"tipo");
                                ing4 = elegirTipo_Tamaño(nombreTamaño,"tamaño");
                                tiempo_demora(pedidoEnc);

                                int subTotal = (int)(pedPizza.precio * porcentajesTamaño[ing4] * porcentajesTipo[ing3])*ing2;
                                DetallePedido nuevoDetalle = new DetallePedido { cantidad = ing2, tipo = nombreTipo[ing3], tamaño = nombreTamaño[ing4], precio = subTotal, PedidoId = pedidoEnc.Id, PizzaId = pedPizza.Id};
                                Services.DetallePedidoService.Save(nuevoDetalle);
                            }
                            break;
                        case 4:
                            Console.Write("Ingrese id de pedido para buscar el detalle a modificar: ");
                            pedidoEnc = buscarPedido();
                            if (pedidoEnc != null && pedidoEnc.estado.Equals(nombreEstados[0]))
                            {
                                mostrarPedido(pedidoEnc);
                                if (pedidoEnc.DetallePedido.Count != 0)
                                {
                                    mostrarDetalle_Pedido(pedidoEnc);
                                    Console.Write("Seleccionar el detalle a modificar: ");
                                    var idDet = Int32.Parse(Console.ReadLine());
                                    DetallePedido detEnc = Services.DetallePedidoService.GetById(idDet, pedidoEnc.Id);
                                    if(detEnc!= null)
                                    {
                                        bool band1,band2,band3,band4;
                                        int val2, val3;
                                        float nuevoSubtotal;

                                        band1 = preguntar("pizza");
                                        if(band1)
                                        {
                                            Pizza pizzaNueva = elegirPizza();
                                            detEnc.PizzaId = pizzaNueva.Id;
                                            nuevoSubtotal = pizzaNueva.precio;
                                        }
                                        else
                                            nuevoSubtotal = detEnc.Pizza.precio;

                                        band2 = preguntar("cantidad");
                                        if(band2)
                                            detEnc.cantidad = ingresarCantidad("nueva");
                                        nuevoSubtotal = nuevoSubtotal * detEnc.cantidad;
                                        
                                        band3 = preguntar("tipo");
                                        if (band3)
                                        {
                                            val2 = elegirTipo_Tamaño(nombreTipo,"nuevo tipo");
                                            detEnc.tipo = nombreTipo[val2];
                                        }
                                        else
                                            val2 = Array.IndexOf(nombreTipo, detEnc.tipo);
                                        nuevoSubtotal = (float)(nuevoSubtotal * porcentajesTipo[val2]);

                                        band4 = preguntar("tamaño");
                                        if(band4)
                                        {
                                            val3 = elegirTipo_Tamaño(nombreTamaño,"nuevo tamaño");
                                            detEnc.tamaño = nombreTamaño[val3];
                                        }
                                        else
                                            val3 = Array.IndexOf(nombreTamaño, detEnc.tamaño);
                                        nuevoSubtotal = (float)(nuevoSubtotal * porcentajesTamaño[val3]);

                                        detEnc.precio = (int)nuevoSubtotal;
                                        if (band1 || band2 || band3 || band4)
                                            tiempo_demora(pedidoEnc);

                                        Services.DetallePedidoService.Save(detEnc);
                                    }
                                }
                                else
                                    Console.WriteLine("No tiene detalles asociados.");

                            }
                            static bool preguntar(String anexo)
                            {
                                Console.Write("Desea modificar su "+anexo+"? 0-si: ");
                                int x = Int32.Parse(Console.ReadLine());
                                return x==0;
                            }
                                break;
                        case 5:
                            Console.Write("Desea cancelar algun pedido (0-si,1-no): ");
                            var res = Int32.Parse(Console.ReadLine());
                            if (res == 0)
                            {
                                pedidos = Services.PedidoService.GetPedidosACancelar();
                                if (pedidos.Count != 0)
                                {
                                    allPedidos(pedidos);
                                    Console.Write("Seleccione un pedido para cancelar: ");
                                    pedidoEnc = buscarPedido();
                                    //verifico que el pedido devuelto no sea nulo y posee estado Encargado o EnPreparacion
                                    if (pedidoEnc != null && (pedidoEnc.estado.Equals(nombreEstados[0]) || pedidoEnc.estado.Equals(nombreEstados[1])))
                                        cambiarEstadoPedido(pedidoEnc, 4, nombreEstados);
                                }
                                else
                                    Console.WriteLine("No existen pedidos para cancelar");
                            }
                            else if(res == 1)
                            {
                                pedidos = Services.PedidoService.GetAll();
                                allPedidos(pedidos);
                                Console.Write("Seleccione un pedido para cambiar su estado: ");
                                pedidoEnc = buscarPedido();
                                if (pedidoEnc != null)
                                {
                                    for (int i=0; i < nombreEstados.Length; i++)
                                    {
                                        //verifico que el pedido coincida con el estado actual, que no sea entregado o cancelado, y tenga detalles
                                        if (pedidoEnc.estado.Equals(nombreEstados[i]) && i<3 && pedidoEnc.DetallePedido.Count>0)
                                        {
                                            cambiarEstadoPedido(pedidoEnc, i + 1, nombreEstados);
                                            break;
                                        }
                                    }
                                    
                                }
                            }
                            static void cambiarEstadoPedido(Pedido p, int j, string[] nombreEstados)
                            {
                                p.estado = nombreEstados[j];
                                Services.PedidoService.Save(p);
                            }
                            break;
                        case 6:
                            Console.Write("Ingrese id de pedido para mostrar detalle/s: ");
                            pedidoEnc = buscarPedido();
                            if (pedidoEnc != null)
                            {
                                mostrarPedido(pedidoEnc);
                                if (pedidoEnc.DetallePedido.Count != 0)
                                {
                                    mostrarDetalle_Pedido(pedidoEnc);
                                }
                                else
                                    Console.WriteLine("No tiene detalles asociados.");
                            }
                            break;
                        case 7:
                            pedidos = Services.PedidoService.GetAll();
                            Console.WriteLine("--Todos los Pedidos de la pizzeria--");
                            allPedidos(pedidos);
                            break;
                        case 8:
                            pedidos = Services.PedidoService.GetPedidosAFacturar();
                            if (pedidos.Count > 0)
                            {
                                Console.WriteLine("--Todos los Pedidos a facturar--");
                                allPedidos(pedidos);
                                Console.Write("Ingrese id de pedido a facturar: ");
                                pedidoEnc = buscarPedido();
                                //verifico que el pedido devuelto no sea nulo y posee estado Preparado o Entregado
                                if (pedidoEnc != null && (pedidoEnc.estado.Equals(nombreEstados[2]) || pedidoEnc.estado.Equals(nombreEstados[3])))
                                {
                                    Factura factNuevo = new Factura { fechaHoraEmision = DateTime.Now, PedidoId = pedidoEnc.Id };
                                    Services.FacturaService.Save(factNuevo);
                                }
                            }
                            else
                                Console.WriteLine("No existen pedidos para generar factura");
                            break;
                        case 9:
                            List<Factura> facturas = Services.FacturaService.GetAll();
                            if (facturas.Count > 0)
                            {
                                Console.WriteLine("--Todas las facturas de la pizzeria--");
                                foreach (var i in facturas)
                                    Console.WriteLine(i.Id + " - " + i.fechaHoraEmision + " - " + i.PedidoId);
                            }
                            else
                                Console.WriteLine("No hay facturas generadas o disponibles");
                            break;
                        default:
                            Console.WriteLine("No existe esa opción.");
                            break;
                    }
                }
            }

            static void allPedidos(List<Pedido> listado)
            {
                foreach (var i in listado)
                    Console.WriteLine(i.Id + " - " + i.fechaHoraEmision + " - " + i.nombreCliente + " - " + i.estado);
            }

            static Pedido buscarPedido()
            {
                var idSel = Int32.Parse(Console.ReadLine());
                return Services.PedidoService.GetById(idSel);
            }

            static Pizza elegirPizza()
            {
                Pizza sel;
                do
                {
                    foreach (var i in Services.PizzaService.GetAll())
                        Console.WriteLine(i.Id + " - " + i.nombre);
                    Console.Write("Elija una pizza: ");
                    int ing1 = Int32.Parse(Console.ReadLine());
                    sel = Services.PizzaService.Get(ing1);
                } while (sel == null);
                return sel;
            }

            static int ingresarCantidad(String a)
            {
                int ing;
                do
                {
                    Console.Write("Ingrese la "+a+" cantidad de pizzas: ");
                    ing = Int32.Parse(Console.ReadLine());
                } while (ing <= 0);
                return ing;
            }

            static int elegirTipo_Tamaño(string[] x, string y)
            {
                int valor;
                do
                {
                    for (int i = 0; i < x.Length; i++)
                        Console.WriteLine(i + " - " + x[i]);
                    Console.Write("Elija un " + y + ": ");
                    valor = Int32.Parse(Console.ReadLine());
                } while (valor < 0 || valor > 2);
                return valor;
            }

            static void tiempo_demora(Pedido z)
            {
                int dem;
                do
                {
                    Console.Write("Ingrese tiempo de demora en minutos: ");
                    dem = Int32.Parse(Console.ReadLine());
                } while (dem <= 0);

                DateTime aux1 = DateTime.Now.AddMinutes(dem);
                if (aux1 > z.fechaHoraEstimada)
                {
                    z.fechaHoraEstimada = aux1;
                    Services.PedidoService.Save(z);
                }
            }

            static void mostrarPedido(Pedido x)
            {
                Console.WriteLine("--Datos del pedido del cliente--");
                Console.WriteLine(x.Id + " - " + x.fechaHoraEmision + " - " + x.nombreCliente + " - " + x.estado);
            }

            static void mostrarDetalle_Pedido(Pedido y)
            {
                Console.WriteLine("Detalles del pedido:");
                foreach (var t in y.DetallePedido)
                {
                    Pizza aux = Services.PizzaService.Get(t.PizzaId);
                    Console.WriteLine("Id: " + t.Id + " - Cantidad: " + t.cantidad + " - Pizza: " + aux.nombre + " -Tipo: " + t.tipo + " -Tamaño: " + t.tamaño + " - Subtotal: " + t.precio);
                }
            }

        }
    }
}