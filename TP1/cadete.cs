using System.Data.Common;
using System.Text;

public class Cadete{

    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoDePedidos;

    public Cadete(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listadoDePedidos = new List<Pedido>();
    }

    public void AsignarPedido(Pedido pedido){
        listadoDePedidos.Add(pedido);
    }

    public void reasignarPedido(Pedido pedido, Cadete otroCadete){
        if (listadoDePedidos.Remove(pedido))
        {
            otroCadete.AsignarPedido(pedido);
        }
    }

    public int cantidadPedidos(){
        return listadoDePedidos.Count;
    }
    public decimal calcularJornal(decimal tarifaPorPedido){
        return listadoDePedidos.Count * tarifaPorPedido;
    }

    public int VerId(){
        return id;
    }
}