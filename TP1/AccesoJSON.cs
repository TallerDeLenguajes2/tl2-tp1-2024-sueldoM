using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoJSON : AccesoADatos
{
    private string cadetesJSONPath;
    private string cadeteriaJSONPath;

    public AccesoJSON(string cadetesJSONPath, string cadeteriaJSONPath)
    {
        this.cadetesJSONPath = cadetesJSONPath;
        this.cadeteriaJSONPath = cadeteriaJSONPath;
    }

    public override List<Cadete> LeerCadetes()
    {
        if (!File.Exists(cadetesJSONPath))
        {
            Console.WriteLine($"El archivo {cadetesJSONPath} no se encuentra.");
            return new List<Cadete>();
        }


            string json = File.ReadAllText(cadetesJSONPath);
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
            return cadetes ?? new List<Cadete>();
    }

    public override Cadeteria LeerCadeteria()
    {
        if (!File.Exists(cadeteriaJSONPath))
        {
            Console.WriteLine($"El archivo {cadeteriaJSONPath} no se encuentra.");
            return null;
        }

        try
        {
            string json = File.ReadAllText(cadeteriaJSONPath);
            var cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            return cadeteria ?? new Cadeteria("Desconocido", "Sin teléfono");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al leer el archivo JSON: {ex.Message}");
            return null;
        }
    }

    public override void GuardarCadetes(List<Cadete> cadetes)
    {
        try
        {
            string json = JsonSerializer.Serialize(cadetes);
            File.WriteAllText(cadetesJSONPath, json);
            Console.WriteLine("Cadetes guardados correctamente en JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar los cadetes en JSON: {ex.Message}");
        }
    }

    public override void GuardarCadeteria(Cadeteria cadeteria)
    {
        try
        {
            string json = JsonSerializer.Serialize(cadeteria);
            File.WriteAllText(cadeteriaJSONPath, json);
            Console.WriteLine("Cadetería guardada correctamente en JSON.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar la cadetería en JSON: {ex.Message}");
        }
    }
}
