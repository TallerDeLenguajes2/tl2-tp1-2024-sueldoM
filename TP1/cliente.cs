public class Cliente {
    public string ?Nombre {get;set;}
    public string ?Direccion {get; set;}
    public string ?Telefono {get; set;}
    public string ?DatosReferenciaDireccion{get;set;}

    public Cliente (string nombre, string direccion, string telefono, string datosreferenciadireccion){
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        DatosReferenciaDireccion = datosreferenciadireccion;
    }
}