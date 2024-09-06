using System;
public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
    }

    public int VerId()
    {
        return id;
    }

    public string VerNombre()
    {
        return nombre;
    }

    public string VerDireccion()
    {
        return direccion;
    }

    public string VerTelefono()
    {
        return telefono;
    }
}
