using System.Collections.Generic;
using System.Linq;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoDeCadetes;
    private List<Pedido> listadoDePedidos; // Nuevo listado para gestionar los pedidos

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        listadoDeCadetes = new List<Cadete>();
        listadoDePedidos = new List<Pedido>();
    }

    public void AgregarCadete(Cadete cadete)
    {
        listadoDeCadetes.Add(cadete);
    }

    public void AgregarPedido(Pedido pedido)
    {
        listadoDePedidos.Add(pedido);
    }

    public void AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var cadete = listadoDeCadetes.FirstOrDefault(c => c.VerId() == idCadete);
        var pedido = listadoDePedidos.FirstOrDefault(p => p.VerId() == idPedido);

        if (cadete != null && pedido != null)
        {
            pedido.AsignarCadete(cadete);
        }
    }

    public decimal JornalACobrar(int idCadete, decimal tarifaPorPedido)
    {
        var cadete = listadoDeCadetes.FirstOrDefault(c => c.VerId() == idCadete);
        if (cadete != null)
        {
            // Contar cuántos pedidos tiene asignados ese cadete
            int pedidosAsignados = listadoDePedidos.Count(p => p.VerCadeteAsignado()?.VerId() == idCadete);
            return pedidosAsignados * tarifaPorPedido;
        }
        return 0;
    }
}
