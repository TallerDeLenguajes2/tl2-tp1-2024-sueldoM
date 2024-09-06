using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AccesoCSV : AccesoADatos
{
    private string cadetePath;
    private string cadeteriaPath;

    public AccesoCSV(string cadetePath, string cadeteriaPath)
    {
        this.cadetePath = cadetePath;
        this.cadeteriaPath = cadeteriaPath;
    }

    public override List<Cadete> LeerCadetes()
    {
        var cadetes = new List<Cadete>();
        if (!File.Exists(cadetePath)) return cadetes;

        var lines = File.ReadAllLines(cadetePath);
        foreach (var line in lines.Skip(1)) // Skip header
        {
            var values = line.Split(',');
            if (values.Length == 4)
            {
                var id = int.Parse(values[0]);
                var nombre = values[1];
                var direccion = values[2];
                var telefono = values[3];
                cadetes.Add(new Cadete(id, nombre, direccion, telefono));
            }
        }
        return cadetes;
    }

    public override Cadeteria LeerCadeteria()
    {
        if (!File.Exists(cadeteriaPath)) return null;

        var lines = File.ReadAllLines(cadeteriaPath);
        if (lines.Length < 2) return null;

        var values = lines[1].Split(',');
        if (values.Length == 2)
        {
            string nombre = values[0];
            string telefono = values[1];
            return new Cadeteria(nombre, telefono);
        }
        return null;
    }

    public override void GuardarCadetes(List<Cadete> cadetes)
    {
        var lines = new List<string>
        {
            "Id,Nombre,Direccion,Telefono"
        };

        lines.AddRange(cadetes.Select(c => $"{c.VerId()},{c.VerNombre()},{c.VerDireccion()},{c.VerTelefono()}"));
        File.WriteAllLines(cadetePath, lines);
    }

    public override void GuardarCadeteria(Cadeteria cadeteria)
    {
        var lines = new List<string>
        {
            "Nombre,Telefono",
            $"{cadeteria.VerNombre()},{cadeteria.VerTelefono()}"
        };
        File.WriteAllLines(cadeteriaPath, lines);
    }
}
