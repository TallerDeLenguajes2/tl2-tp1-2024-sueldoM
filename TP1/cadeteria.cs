public class Cadeteria{
    public string ?Nombre {get; private set;}
    public string ?Telefono {get; private set;}
    public List<Cadete> ListadodeCadetes {get; private set;}

    private Cadeteria(){
        ListadodeCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete){
        ListadodeCadetes.Add(cadete);
    }

    public void removerCadete(int id){
        var cadete = ListadodeCadetes.FirstOrDefault(c => c.Id == id);
        if (cadete != null)
        {
            ListadodeCadetes.Remove(cadete);
        }
    }

    public Cadete BuscarCadete(int id){
        return ListadodeCadetes.FirstOrDefault(c => c.Id == id);
    }

    public void reasignarPedido(int nroPedido, int idCadeteOriginal, int idCadeteNuevo){
        var cadeteOriginal = BuscarCadete(idCadeteOriginal);
        var cadeteNuevo = BuscarCadete(idCadeteNuevo);
        var pedido = cadeteOriginal?.ListadodePedidos.FirstOrDefault(p => p.Nro == nroPedido);

        if (pedido != null && cadeteNuevo != null){
            cadeteOriginal.reasignarPedido(pedido, cadeteNuevo);
        }
    }

    
}