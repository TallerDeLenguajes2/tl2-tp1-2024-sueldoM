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
        return Cliente?.verDireccion();
    }

    public string DatosCliente(){
        return $"Nombre: {Cliente?.verNombre()}, Direccion: {Cliente?.verDireccion()}, Telefono: {Cliente?.verTelefono()}";
    }

    public void cambiarEstado(string nuevoEstado){
        Estado = nuevoEstado;
    }
}