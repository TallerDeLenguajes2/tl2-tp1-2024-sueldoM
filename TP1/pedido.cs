public class Pedido{
    private int ?nro;
    private string ?obs;
    private Cliente ?cliente;
    private string ?estado;

    public Pedido(int n, string observacion, string nombre, string direccion, string telefono, string datosReferenciaDireccion){
        nro = n;
        obs = observacion;
        cliente =  new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
        estado = "Pendiente";
    }

    public string ?DireccionCliente(){
        return cliente?.verDireccion();
    }

    public string DatosCliente(){
        return $"Nombre: {cliente?.verNombre()}, Direccion: {cliente?.verDireccion()}, Telefono: {cliente?.verTelefono()}";
    }

    public void cambiarEstado(string nuevoEstado){
        estado = nuevoEstado;
    }
}