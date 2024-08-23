public class Cadeteria{
    public string ?Nombre {get; set;}
    public string ?Telefono {get; set;}
    public List<Cadete> ListadodeCadetes {get; set;}

    private Cadeteria(){
        ListadodeCadetes = new List<Cadete>();
    }
}