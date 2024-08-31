public class Cadeteria{
    private string ?nombre;
    private string ?telefono;
    public List<Cadete> listadodeCadetes;

    public Cadeteria(){
        listadodeCadetes = new List<Cadete>();
    }

    public void AgregarCadete(Cadete cadete){
        listadodeCadetes.Add(cadete);
    }

    public void removerCadete(int id){
        var cadete = listadodeCadetes.FirstOrDefault(c => c.VerId() == id);
        if (cadete != null)
        {
            listadodeCadetes.Remove(cadete);
        }
    }

}