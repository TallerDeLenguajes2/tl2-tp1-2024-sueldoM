public class Pedido{
    public int ?Nro {get; private set;}
    public string ?Obs {get; private set;}
    public Cliente ?Cliente{get; private set;}
    public string ?Estado {get; private set;}

    public string ?DireccionCliente(){
        return Cliente?.Direccion;
    }

    public string DatosCliente(){
        return $"Nombre: {Cliente?.Nombre}, Direccion: {Cliente?.Direccion}, Telefono: {Cliente?.Telefono}";
    }
}