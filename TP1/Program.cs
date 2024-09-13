using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Program
{
    static AccesoADatos? accesoADatos;
    static void Main(string[] args)
    {
        // Configura la ruta de los archivos CSV
        string currentDirectory = Directory.GetCurrentDirectory();
        string cadetePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cadete.csv");
        string cadeteriaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cadeteria.csv");

        string cadeteJSONPath = Path.Combine(Directory.GetCurrentDirectory(), "cadete.json");
        string cadeteriaJSONPath = Path.Combine(Directory.GetCurrentDirectory(), "cadeteria.json");

        Console.WriteLine("Seleccione el tipo de acceso a datos:");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        string tipoAcceso = Console.ReadLine();

        switch (tipoAcceso)
        {
        case "1":
            accesoADatos = new AccesoCSV(cadetePath, cadeteriaPath);
            break;
        case "2":
            accesoADatos = new AccesoJSON(cadeteJSONPath, cadeteriaJSONPath);
            break;
        default:
            Console.WriteLine("Opción no válida.");
            return;
        }

        // Cargar datos desde los archivos CSV
        var cadetes = accesoADatos.LeerCadetes();
        var cadeteria = accesoADatos.LeerCadeteria();

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
            Console.WriteLine("7. Mostrar Cadetes.csv");
            Console.WriteLine("8. Mostrar Cadeteria.csv");

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
                        string? idPedido = Console.ReadLine();
                        if (int.TryParse(idPedido, out int idPed))
                        {
                            Pedido? pedidoAReasignar = cadeteria?.listadoDePedidos?.FirstOrDefault(p => p.VerId() == idPed);
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
                                decimal? jornal = cadeteria.JornalACobrar(idCadeteInt, tarifaPorPedido);
                                Console.WriteLine($"El jornal a cobrar para el cadete con ID {idCadeteInt} es: {jornal:C}");
                            }
                            else
                            {
                                Console.WriteLine("Tarifa no válida.");
                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Saliendo...");
                        return;
                    case 7:
                        Console.WriteLine("Lista de cadetes:");
                        foreach (var cadete in cadetes)
                        {
                            Console.WriteLine($"ID: {cadete.VerId()}, Nombre: {cadete.VerNombre()}, Dirección: {cadete.VerDireccion()}, Teléfono: {cadete.VerTelefono()}");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Información de Cadeteria:");
                        if (cadeteria != null)
                        {
                            Console.WriteLine($"Nombre: {cadeteria.VerNombre()}, Teléfono: {cadeteria.VerTelefono()}");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo cargar la información de la Cadeteria.");
                        }
                        break;

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
        }

        try
        {
            var lines = File.ReadAllLines(path);

            // Saltar la cabecera
            foreach (var line in lines.Skip(1))
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

static Cadeteria LeerCadeteriaDesdeCSV(string path)
{
    if (!File.Exists(path))
    {
        Console.WriteLine($"El archivo {path} no se encuentra.");
        return null;
    }

    try
    {
        var lines = File.ReadAllLines(path);

        // Asegúrate de que haya al menos una línea (la cabecera y la información real)
        if (lines.Length < 2)
        {
            Console.WriteLine("El archivo no contiene datos suficientes.");
            return null;
        }

        var values = lines[1].Split(',');
        if (values.Length == 2)
        {
            string nombre = values[0];
            string telefono = values[1];
            return new Cadeteria(nombre, telefono); // Asegúrate de que Cadeteria tenga un constructor adecuado
        }
        else
        {
            Console.WriteLine("Formato de datos en el archivo no válido.");
            return null;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Se produjo una excepción al leer el archivo: {ex.Message}");
        return null;
    }
}

}