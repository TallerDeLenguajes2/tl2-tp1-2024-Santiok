namespace Cadete;
using Pedidos;

public class cadete
{
    public int ID;
    public string Nombre;
    public string Direccion;
    public string Telefono;
    public List<pedididos> ListadoPedidos;

    //Metodo constructor.
    public cadete(int id, string nom, string dir, string tel)
    {
        this.ID = id;
        this.Nombre = nom;
        this.Direccion = dir;
        this.Telefono = tel;
    }


}