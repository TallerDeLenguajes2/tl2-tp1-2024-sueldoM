using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    static void Main(string[] args)
    {
        // Configura la ruta de los archivos CSV
        string cadetePath = Path.Combine(Directory.GetCurrentDirectory(), "net8.0", "cadete.csv");
        string cadeteriaPath = Path.Combine(Directory.GetCurrentDirectory(), "net8.0", "cadeteria.csv");

        // Cargar datos desde los archivos CSV
        List<Cadete> cadetes = LeerCadetesDesdeCSV(cadetePath);
        Cadeteria cadeteria = LeerCadeteriaDesdeCSV(cadeteriaPath, cadetes);

        int n = 0;
        int x = 0;
        int d;
        Pedido pedido = null; // Declarar la variable fuera del switch

        while (x < 10)
        {
            Console.WriteLine("----Menú----");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignarlos a un Cadete");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro Cadete");
            Console.WriteLine("5. Calcular jornal a cobrar");
            Console.WriteLine("6. Guardar y Salir");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out x))
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Crear nuevo pedido:");
                        Console.Write("Observación: ");
                        string? observacion = Console.ReadLine();
                        Console.Write("Nombre del cliente: ");
                        string? nombre = Console.ReadLine();
                        Console.Write("Dirección del cliente: ");
                        string? direccion = Console.ReadLine();
                        Console.Write("Teléfono del cliente: ");
                        string? telefono = Console.ReadLine();
                        Console.Write("Datos de referencia de dirección: ");
                        string? datosReferenciaDireccion = Console.ReadLine();
                        Cliente? cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
                        pedido = new Pedido(n, observacion, cliente);
                        cadeteria.AgregarPedido(pedido);
                        n++;
                        Console.WriteLine($"Pedido {n} creado con éxito.");
                        break;

                    case 2:
                        if (pedido == null)
                        {
                            Console.WriteLine("No hay ningún pedido creado para asignar.");
                            break;
                        }
                        Console.WriteLine("¿Qué cadete tomará el pedido?");
                        Console.Write("Ingrese el ID del cadete: ");
                        string? id = Console.ReadLine();
                        if (int.TryParse(id, out d))
                        {
                            Cadete? cadete = cadetes.FirstOrDefault(c => c.VerId() == d);
                            if (cadete != null)
                            {
                                pedido.AsignarCadete(cadete);
                                Console.WriteLine($"Pedido asignado al cadete con ID {d}.");
                            }
                            else
                            {
                                Console.WriteLine("Cadete no encontrado.");
                            }
                        }
                        break;

                    case 3:
                        if (pedido == null)
                        {
                            Console.WriteLine("No hay ningún pedido creado para cambiar su estado.");
                            break;
                        }
                        Console.WriteLine("Cambiar estado de un pedido:");
                        Console.Write("Ingrese el nuevo estado: ");
                        string? nuevoEstado = Console.ReadLine();
                        pedido.CambiarEstado(nuevoEstado);
                        Console.WriteLine("Estado del pedido cambiado con éxito.");
                        break;

                    case 4:
                        Console.WriteLine("Reasignar pedido a otro cadete:");
                        Console.Write("Ingrese el ID del pedido: ");
                        string idPedido = Console.ReadLine();
                        if (int.TryParse(idPedido, out int idPed))
                        {
                            Pedido pedidoAReasignar = cadeteria.ListadoDePedidos.FirstOrDefault(p => p.VerId() == idPed);
                            if (pedidoAReasignar != null)
                            {
                                Console.Write("Ingrese el ID del nuevo cadete: ");
                                string? idNuevo = Console.ReadLine();
                                if (int.TryParse(idNuevo, out int idCadeteNuevo))
                                {
                                    Cadete? nuevoCadete = cadetes.FirstOrDefault(c => c.VerId() == idCadeteNuevo);
                                    if (nuevoCadete != null)
                                    {
                                        pedidoAReasignar.AsignarCadete(nuevoCadete);
                                        Console.WriteLine("Pedido reasignado con éxito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nuevo cadete no encontrado.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Pedido no encontrado.");
                            }
                        }
                        break;

                    case 5:
                        Console.Write("Ingrese el ID del cadete para calcular el jornal: ");
                        string? idCadete = Console.ReadLine();
                        if (int.TryParse(idCadete, out int idCadeteInt))
                        {
                            Console.Write("Ingrese la tarifa por pedido: ");
                            string? tarifa = Console.ReadLine();
                            if (decimal.TryParse(tarifa, out decimal tarifaPorPedido))
                            {
                                decimal jornal = cadeteria.JornalACobrar(idCadeteInt, tarifaPorPedido);
                                Console.WriteLine($"El jornal a cobrar para el cadete con ID {idCadeteInt} es: {jornal:C}");
                            }
                            else
                            {
                                Console.WriteLine("Tarifa no válida.");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Guardando datos y saliendo...");
                        GuardarCadetesEnCSV(cadetePath, cadetes);
                        GuardarCadeteriaEnCSV(cadeteriaPath, cadeteria);
                        return;

                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida, intente nuevamente.");
            }
        }
    }

    static List<Cadete> LeerCadetesDesdeCSV(string path)
    {
        List<Cadete> cadetes = new List<Cadete>();

        if (!File.Exists(path))
        {
            Console.WriteLine($"El archivo {path} no se encuentra.");
            return cadetes;
        }

        try
        {
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                int id = int.Parse(values[0]);
                string nombre = values[1];
                string direccion = values[2];
                string telefono = values[3];
                cadetes.Add(new Cadete(id, nombre, direccion, telefono));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Se produjo una excepción al leer el archivo: {ex.Message}");
        }

        return cadetes;
    }

    static Cadeteria LeerCadeteriaDesdeCSV(string path, List<Cadete> cadetes)
    {
        Cadeteria cadeteria = new Cadeteria("Nombre de Cadeteria", "Teléfono de Cadeteria");
        foreach (var cadete in cadetes)
        {
            cadeteria.AgregarCadete(cadete);
        }
        return cadeteria;
    }

    static void GuardarCadetesEnCSV(string path, List<Cadete> cadetes)
    {
        List<string> lines = new List<string>();

        foreach (var cadete in cadetes)
        {
            lines.Add($"{cadete.VerId()},{cadete.VerNombre()},{cadete.VerDireccion()},{cadete.VerTelefono()}");
        }

        File.WriteAllLines(path, lines);
    }

    static void GuardarCadeteriaEnCSV(string path, Cadeteria cadeteria)
    {
        // Para guardar la cadeteria, puedes extender este método según las necesidades específicas.
    }
}
