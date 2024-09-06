using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class AccesoJSON : AccesoADatos
{
    private string cadetePath;
    private string cadeteriaPath;

    public AccesoJSON(string cadetePath, string cadeteriaPath)
    {
        this.cadetePath = cadetePath;
        this.cadeteriaPath = cadeteriaPath;
    }

    public override List<Cadete> LeerCadetes()
    {
        if (!File.Exists(cadetePath)) return new List<Cadete>();

        var json = File.ReadAllText(cadetePath);
        return JsonSerializer.Deserialize<List<Cadete>>(json) ?? new List<Cadete>();
    }

    public override Cadeteria LeerCadeteria()
    {
        if (!File.Exists(cadeteriaPath)) return null;

        var json = File.ReadAllText(cadeteriaPath);
        return JsonSerializer.Deserialize<Cadeteria>(json);
    }

    public override void GuardarCadetes(List<Cadete> cadetes)
    {
        var json = JsonSerializer.Serialize(cadetes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(cadetePath, json);
    }

    public override void GuardarCadeteria(Cadeteria cadeteria)
    {
        var json = JsonSerializer.Serialize(cadeteria, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(cadeteriaPath, json);
    }
}
