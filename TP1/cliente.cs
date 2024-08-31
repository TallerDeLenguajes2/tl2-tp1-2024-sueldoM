public class Cliente {
    private string? nombre ;
    private string? direccion ;
    private string? telefono ;
    private string? datosReferenciaDireccion;

    public Cliente (string nombre, string direccion, string telefono, string datosReferenciaDireccion){
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.datosReferenciaDireccion = datosReferenciaDireccion;
    }

    public string? verNombre(){
        return nombre;
    }
    public string? verDireccion(){
        return direccion;
    }
    public string? verTelefono(){
        return telefono;
    }
    public string? verDatosReferenciaDireccion(){
        return datosReferenciaDireccion;
    }
}