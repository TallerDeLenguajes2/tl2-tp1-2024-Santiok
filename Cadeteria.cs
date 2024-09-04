namespace Cadeteria;
using Cadete;

public class cadeteria
{
    public string Nombre;
    public string Telefono;
    private List<cadete> listadoCadetes;

    //Metodo constructor.
    cadeteria CrearCadeteria(nom, tel)
    {
        cadeteria cad;

        this.Nombre = nom;
        this.Telefono = tel;

        return cad;
    }
}