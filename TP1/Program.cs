// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cadete> cadetes = LeerCadetesDesdeCSV("./cadete.csv");
        Cadeteria cadeteria = LeerCadeteriaDesdeCSV("./cadeteria.csv", cadetes);
        int n = 0;
        int x = 0;
        int d;
        Pedido pedido = null;

        while (x <10)
        {
            Console.WriteLine("-----Menu----");
            Console.WriteLine("1. Dar de alta pedidos");
            Console.WriteLine("2. Asignarlos a un Cadete");
            Console.WriteLine("3. Cambiar estado de un pedido");
            Console.WriteLine("4. Reasignar pedido a otro Cadete");
            Console.WriteLine("5. Salir");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out x))
            {
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Crear Pedido:");
                        Console.Write("Observacion: ");
                        string? observacion = Console.ReadLine();
                        Console.Write("Nombre del Cliente: ");
                        string? nombre = Console.ReadLine();
                        Console.Write("Direccion del Cliente: ");
                        string? direccion = Console.ReadLine();
                        Console.Write("Telefono del Cliente: ");
                        string? telefono = Console.ReadLine();
                        Console.Write("Datos de referencia de direccion: ");
                        string? datosReferenciaDireccion = Console.ReadLine();
                        Cliente? cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
                        pedido = new Pedido(n, observacion, nombre, direccion, telefono, datosReferenciaDireccion);
                        n++;
                        Console.WriteLine($"Pedido {n} creado con exito...");
                        break;

                    case 2:
                        Console.WriteLine("Que cadete tomara el pedido:");
                        Console.Write("Ingrese el ID, del cadete: ");
                        string? id = Console.ReadLine();
                        if (int.TryParse(id, out d))
                            {
                                Cadete? cadete = cadeteria.listadodeCadetes.FirstOrDefault(c => c.VerId() == d);
                                if (cadete != null)
                                {
                                    cadete.AsignarPedido(pedido);
                                    Console.WriteLine($"Pedido asignado al cadete con ID {d}");
                                }
                                else
                                {
                                    Console.WriteLine("Cadete no encontrado");
                                }
                            }
                        break;

                    case 3:
                        Console.WriteLine("Cambiar estado de un pedido: ");
                        Console.Write("Ingrese el nuevo estado: ");
                        string? nuevoEstado = Console.ReadLine();
                        pedido.cambiarEstado(nuevoEstado);
                        Console.WriteLine("Estado del pedido ha cambiado...");
                        break;

                    case 4:
                        Console.WriteLine("Reasignar pedido a otro cadete: ");
                        Console.Write("Ingrese el ID del cadete actual: ");
                        string? idActual = Console.ReadLine();
                        if (int.TryParse(idActual, out int idCadeteActual))
                        {
                            Cadete cadeteActual = cadetes.FirstOrDefault(c => c.VerId() == idCadeteActual);
                            if(cadeteActual != null)
                            {
                                Console.Write("Ingrese el ID del nuevo Cadete: ");
                                string? idNuevo = Console.ReadLine();
                                if(int.TryParse(idNuevo, out int idCadeteNuevo))
                                {
                                    Cadete nuevoCadete = cadetes.FirstOrDefault(c => c.VerId() == idCadeteNuevo);
                                    if (nuevoCadete != null)
                                    {
                                        cadeteActual.reasignarPedido(pedido, nuevoCadete);
                                        Console.WriteLine("Pedido reasignado con exito...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encontro el nuevo cadete...");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontro al cadete actual...");
                            }
                            
                        }
                        break;
                    
                    case 5:
                        Console.WriteLine("Guardando datos....");
                        Console.WriteLine("Saliendo...");
                        GuardarCadeteEnCSV("cadete.csv", cadetes);
                        GuardarCadeteriaenCSV("cadeteria.csv", cadeteria);
                        return;

                    default:
                        Console.WriteLine("Opcion invalida, por favor vuelva a intentar...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no valida, intente nuevamente....");
            }
        }


    }

    static List<Cadete> LeerCadetesDesdeCSV(string path)
    {
        List<Cadete> cadetes = new List<Cadete>();
        var lines = File.ReadAllLines(path);

        foreach(var line in lines)
        {
            var values = line.Split(',');
            int id = int.Parse(values[0]);
            string nombre = values[1];
            string direccion = values[2];
            string telefono = values[3];
            cadetes.Add(new Cadete(id, nombre, direccion, telefono));
        }
        return cadetes;
    }

    static Cadeteria LeerCadeteriaDesdeCSV(string path, List<Cadete> cadetes)
    {
        Cadeteria cadeteria = new Cadeteria();
        foreach (var cadete in cadetes)
        {
            cadeteria.AgregarCadete(cadete);
        }
        return cadeteria;
    }

    static void GuardarCadeteEnCSV(string path, List<Cadete> cadetes)
    {
        List<string> lines = new List<string>();

        foreach (var cadete in cadetes)
        {
            lines.Add($"{cadete.VerId()},{cadete.VerNombre()},{cadete.VerDireccion()},{cadete.VerTelefono()}");
        }
        File.WriteAllLines(path, lines);
    }

    static void GuardarCadeteriaenCSV(string path, Cadeteria cadeteria)
    {

    }
}