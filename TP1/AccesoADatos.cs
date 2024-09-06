public abstract class AccesoADatos
{
    public abstract List<Cadete> LeerCadetes();
    public abstract Cadeteria LeerCadeteria();
    public abstract void GuardarCadetes(List<Cadete> cadetes);
    public abstract void GuardarCadeteria(Cadeteria cadeteria);
}
