public class Cadeteria{
    public string Nombre {get; set;}
    public string Telefono {get; set;}
    public List<Cadete> ListadodeCadetes {get; set;}

    public Cadeteria(){
        ListadodeCadetes = new List<Cadete>();
    }
}