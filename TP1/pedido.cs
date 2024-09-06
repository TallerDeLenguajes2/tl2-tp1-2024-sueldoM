public class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private string estado;
    private Cadete? cadeteAsignado; // Referencia al cadete asignado, puede ser null

    public Pedido(int n, string observacion, Cliente cliente)
    {
        nro = n;
        obs = observacion;
        this.cliente = cliente;
        estado = "Pendiente";
        cadeteAsignado = null; // Inicialmente, sin cadete asignado
    }

        public int VerId()
    {
        return nro;
    }

    public string DireccionCliente()
    {
        return cliente?.verDireccion();
    }

    public string DatosCliente()
    {
        return $"Nombre: {cliente?.verNombre()}, Dirección: {cliente?.verDireccion()}, Teléfono: {cliente?.verTelefono()}";
    }

    public void CambiarEstado(string nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public void AsignarCadete(Cadete cadete)
    {
        cadeteAsignado = cadete;
    }

    public bool TieneCadeteAsignado()
    {
        return cadeteAsignado != null;
    }

    public Cadete? VerCadeteAsignado()
    {
        return cadeteAsignado;
    }
}
