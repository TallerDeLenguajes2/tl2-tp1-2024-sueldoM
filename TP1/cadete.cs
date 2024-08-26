using System.Text;

public class Cadete{
    public int ?Id {get; private set;}
    public string ?Nombre {get; private set;}
    public string ?Direccion {get; private set;}
    public List<Pedido> ListadodePedidos {get; private set;}

    public Cadete(){
        ListadodePedidos = new List<Pedido>();
    }

    public int TotalaCobrar(){
        return 0;
    }

}