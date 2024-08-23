public class Pedido{
    public int Nro {get; set;}
    public string Obs {get; set;}
    public Cliente cliente{get; set;}
    public string Estado {get; set;}

    public string DireccionCliente(){
        return cliente?.Direccion;
    }

    public string DatosCliente(){
        return $"Nombre: {cliente?.Nombre}, Direccion: {cliente?.Direccion}, Telefono: {cliente?.Telefono}";
    }
}