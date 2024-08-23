public class Pedido{
    public int ?Nro {get; set;}
    public string ?Obs {get; set;}
    public Cliente ?Cliente{get; set;}
    public string ?Estado {get; set;}

    public string ?DireccionCliente(){
        return Cliente?.Direccion;
    }

    public string DatosCliente(){
        return $"Nombre: {Cliente?.Nombre}, Direccion: {Cliente?.Direccion}, Telefono: {Cliente?.Telefono}";
    }
}