namespace Cadete;
using Pedidos;

public class cadete
{
    private int ID;
    public string Nombre;
    private string Direccion;
    private string Telefono;
    private List<pedididos> ListadoPedidos;

    //Metodo constructor.
    cadete CrearCadete(id, nom, dir, tel)
    {
        cadete cad;

        this.ID = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;

        return cad;
    }
}