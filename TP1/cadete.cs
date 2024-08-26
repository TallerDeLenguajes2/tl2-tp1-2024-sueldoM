using System.Text;

public class Cadete{
    public int ?Id {get; private set;}
    public string ?Nombre {get; private set;}
    public string ?Direccion {get; private set;}
    public string ?Telefono {get; private set;}
    public List<Pedido> ?ListadodePedidos {get; private set;}

    public Cadete(int id, string nombre, string direccion, string telefono){
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        ListadodePedidos = new List<Pedido>();
    }

    public void AsignarPedido(Pedido pedido){
        ListadodePedidos.Add(pedido);
    }

    public void reasignarPedido(Pedido pedido, Cadete otroCadete){
        if (ListadodePedidos.Remove(pedido))
        {
            otroCadete.AsignarPedido(pedido);
        }
    }

    public int cantidadPedidos(){
        return ListadodePedidos.Count;
    }
    public int TotalaCobrar(){
        return 0;
    }

}