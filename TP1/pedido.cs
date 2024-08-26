public class Pedido{
    public int ?Nro {get; private set;}
    public string ?Obs {get; private set;}
    public Cliente ?Cliente{get; private set;}
    public string ?Estado {get; private set;}

    public Pedido(int nro, string observacion, Cliente cliente){
        Nro = nro;
        Obs = observacion;
        Cliente = cliente;
        Estado = "Pendiente";
    }

    public string ?DireccionCliente(){
        return Cliente?.Direccion;
    }

    public string DatosCliente(){
        return $"Nombre: {Cliente?.Nombre}, Direccion: {Cliente?.Direccion}, Telefono: {Cliente?.Telefono}";
    }

    public void cambiarEstado(string nuevoEstado){
        Estado = nuevoEstado;
    }
}