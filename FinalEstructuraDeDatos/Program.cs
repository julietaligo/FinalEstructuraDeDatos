using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalEstructuraDeDatos
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Queue<int> cola = null;

            bool salir = false;

            Console.WriteLine("----------SISTEMA DE PEDIDOS----------");

            while (salir != true)
            {
                Console.WriteLine(
                "\n1. Crear Cola" +
                "\n2. Borrar Cola" +
                "\n3. Agregar Pedido" +
                "\n4. Borrar Pedido" +
                "\n5. Listar todos los Pedidos" +
                "\n6. Listar ultimo Pedido" +
                "\n7. Listar primer Pedido" +
                "\n8. Cantidad de Pedido" +
                "\n9. Salir" +
                "\n10. Chequear si existe elemento en la Cola" +
                "\n11. Modificar Pedido a salir");

                Console.WriteLine("\nOpcion: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        cola = new Queue<int>();
                        Console.WriteLine("Se creo la cola.");
                        break;
                    case 2:
                        BorrarCola(cola);
                        break;
                    case 3:
                        AgregarPedido(cola);
                        break;
                    case 4:
                        BorrarPedido(cola);
                        break;
                    case 5:
                        ListarPedidos(cola);
                        break;
                    case 6:
                        ListarUltimoPedido(cola);
                        break;
                    case 7:
                        ListarPrimerPedido(cola);
                        break;
                    case 8:
                        ImprimirCantidadPedido(cola);
                        break;
                    case 9:
                        salir = true;
                        break;
                    case 10:
                        ValidarExistenciaElemento(cola);
                        break;
                    case 11:
                        cola = ModificarPedidoASalir(cola);
                        break;
                    default:
                        break;
                }
            }
        }

        //Agrego el pedido en la cola
        private static void AgregarPedido(Queue<int> cola)
        {
            int cant = 0;

            if (cola != null)
            {
                cant = ValidarCantidad();
                cola.Enqueue(cant);
                Console.WriteLine("Se agrego el pedido a la cola.");
            }
            else
            {
                Console.WriteLine("No existe cola. Para crearla elija la opcion 1.");
            }
        }

        //Valido que la cantidad ingresada sea entre 0 y 999.
        private static int ValidarCantidad()
        {
            Console.WriteLine("Ingrese la cantidad: ");
            int cant = Convert.ToInt32(Console.ReadLine());
            while (cant < 0 || cant > 999)
            {
                Console.WriteLine("Debe ingresar un numero entre 0 y 999.");
                Console.WriteLine("Ingrese la cantidad: ");
                cant = Convert.ToInt32(Console.ReadLine());
            }
            return cant;
        }

        //Vacio la cola
        private static void BorrarCola(Queue<int> cola)
        {
            if (cola != null)
            {
                cola.Clear();
                Console.WriteLine("Se vacio la cola.");
            }
            else
            {
                Console.WriteLine("No existe cola. Para crearla elija la opcion 1.");
            }
        }

        //Elimino el ultimo pedido
        private static void BorrarPedido(Queue<int> cola)
        {
            if (cola != null && cola.Count > 0)
            {
                Console.WriteLine("Se elimino el pedido " + cola.Peek());
                cola.Dequeue();
            }
            else
            {
                Console.WriteLine("No existe cola o no hay pedidos.");
            }
        }

        //Listo los pedidos de la cola
        private static void ListarPedidos(Queue<int> cola)
        {
            if (cola != null && cola.Count > 0)
            {
                int count = 1;
                foreach (int pedido in cola)
                {
                    Console.WriteLine(count + " - " + pedido);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No existe cola o no hay pedidos.");
            }
        }

        //Imprimo el ultimo pedido de la cola
        private static void ListarUltimoPedido(Queue<int> cola)
        {
            if (cola != null && cola.Count > 0)
            {
                Console.WriteLine("Ultimo Pedido: " + cola.Last());
            }
            else
            {
                Console.WriteLine("No existe cola o no hay pedidos.");
            }
        }

        //Imprimo el primer pedido de la cola
        private static void ListarPrimerPedido(Queue<int> cola)
        {
            if (cola != null && cola.Count > 0)
            {
                Console.WriteLine("Primer Pedido: " + cola.Peek());
            }
            else
            {
                Console.WriteLine("No existe cola o no hay pedidos.");
            }
        }

        //Imprimo la cantidad de pedidos de la cola
        private static void ImprimirCantidadPedido(Queue<int> cola)
        {
            if (cola != null)
            {
                Console.WriteLine("Total de Pedidos:" + cola.Count);
            }
            else
            {
                Console.WriteLine("No existe cola. Para crearla elija la opcion 1.");
            }
        }

        //Valido si existe el elemento en la cola
        private static void ValidarExistenciaElemento(Queue<int> cola)
        {
            if (cola != null && cola.Count > 0)
            {
                Console.WriteLine("Ingrese el elemento a validar: ");
                int elemento = Convert.ToInt32(Console.ReadLine());

                if (cola.Contains(elemento) == true)
                {
                    Console.WriteLine("La cola contiene el elemento " + elemento);
                }
                else
                {
                    Console.WriteLine("La cola no contiene el elemento " + elemento);
                }
            }
            else
            {
                Console.WriteLine("No existe cola o no hay pedidos.");
            }
        }

        //Modifico el ultimo pedido de la cola
        private static Queue<int> ModificarPedidoASalir(Queue<int> cola)
        {
            Queue<int> nueva_cola = null;
            if (cola != null && cola.Count > 0)
            {
                int cant_anterior = cola.Dequeue();
                List<int> lista = cola.ToList<int>();
                int cant = ValidarCantidad();
                lista.Insert(0, cant);
                Console.WriteLine("Se modifico el Pedido.");
                Console.WriteLine("CANTIDAD ANTERIOR: " + cant_anterior + "\nCANTIDAD ACTUAL: " + cant);
                nueva_cola = new Queue<int>(lista);
            }
            else
            {
                Console.WriteLine("No se puede modificar. La cola no existe o se encuentra vacia.");
            }

            return nueva_cola;
        }
    }
}
