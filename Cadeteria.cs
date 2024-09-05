namespace Cadeteria;
using Cadete;

public class cadeteria
{
    public string Nombre;
    public string Telefono;
    private List<cadete> listadoCadetes;

    //Metodo constructor.
    public cadeteria(string nom, string tel)
    {
        this.Nombre = nom;
        this.Telefono = tel;
    }
}

