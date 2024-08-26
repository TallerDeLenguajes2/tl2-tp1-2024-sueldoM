public class Cadeteria{
    public string ?Nombre {get; private set;}
    public string ?Telefono {get; private set;}
    public List<Cadete> ListadodeCadetes {get; private set;}

    private Cadeteria(){
        ListadodeCadetes = new List<Cadete>();
    }
}