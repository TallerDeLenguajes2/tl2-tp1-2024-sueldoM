using System.Text;

public class Cadete{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public string Direccion {get; set;}
    public List<Pedido> ListadodePedidos {get; set;}

    public Cadete(){
        ListadodePedidos = new List<Pedido>();
    }

    public int TotalaCobrar(){
        return 0;
    }

}